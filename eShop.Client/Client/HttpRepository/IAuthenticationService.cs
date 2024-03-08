using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.HttpRepository
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(CreateUserDto userForRegistration);

        Task<AuthResponseDto> Login(AuthenticateUserDto userForAuthentication);

        Task Logout();
    }
}