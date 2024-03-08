using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using SharedAPI.Data_Transfer;

namespace Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        private User? User;

        public AuthService(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var claims = await GetClaims();
            var signingCreds = GetSigningCredentials();
            var tokenOptions = GetTokenOptions(claims, signingCreds);

            var tokenHandler = new JwtSecurityTokenHandler();

            string accessToken = tokenHandler.WriteToken(tokenOptions);

            User.RefreshToken = GenerateRefreshToken();

            if (populateExp)
            {
                User.RefreshTokenExpiry = DateTime.Now.AddDays(7);
            }
            await userManager.UpdateAsync(User);

            return new TokenDto
            { accessToken = accessToken, refreshToken = User.RefreshToken };
        }

        public async Task<IdentityResult> RegisterUser(CreateUserDto createUserDto)
        {
            var user = mapper.Map<User>(createUserDto);

            user.UserName = createUserDto.Email;

            var result = await userManager.CreateAsync(user, createUserDto.Password);

            if(result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, createUserDto.Roles);
            }
            return result;
        }

        public async Task<bool> AuthenticateUser(AuthenticateUserDto authenticateUserDto)
        {
            User = await userManager.FindByEmailAsync(authenticateUserDto.email);

            bool result = User != null && await userManager.CheckPasswordAsync(User, authenticateUserDto.password);

            return result;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, User.UserName),
                new Claim(ClaimTypes.Email, User.Email)
            };

            var roles = await userManager.GetRolesAsync(User);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var settings = configuration.GetSection("JwtSettings");

            var signingCreds = new SigningCredentials(new SymmetricSecurityKey
                (System.Text.Encoding.UTF8.GetBytes(settings["SigningKey"])), 
                SecurityAlgorithms.HmacSha256);

            return signingCreds;
        }

        private JwtSecurityToken GetTokenOptions(List<Claim> claims, SigningCredentials signingCreds)
        {
            var settings = configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(issuer: settings["ValidIssuer"],
                signingCredentials: signingCreds,
                audience: settings["ValidAudience"],
                expires: DateTime.Now.AddDays(Convert.ToDouble(settings["expires"])),
                claims: claims);

            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            byte[] token = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(token);
            }
            return Convert.ToBase64String(token);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string accessToken)
        {
            var settings = configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = settings["ValidIssuer"],
                ValidAudience = settings["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(settings["SigningKey"]))
            };
            SecurityToken securityToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

            var token = securityToken as JwtSecurityToken;
            if(principal is null || !token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }
             
            return principal;
        }

        public async Task<TokenDto> RefreshToken(string accessToken, string refreshToken)
        {
            var Principal = GetPrincipalFromToken(accessToken);

            var user = await userManager.FindByEmailAsync(Principal.Identity.Name);

            if (user is null || user.RefreshTokenExpiry <= DateTime.Now || user.RefreshToken != refreshToken)
            {
                throw new BadRequestException("One or more invalid request details");
            }

            User = user;
            return await CreateToken(populateExp: false);
        }
    }
}
