﻿using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class Registration
    {
        private CreateUserDto _userForRegistration = new CreateUserDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public bool ShowRegistrationErros { get; set; }
        public IEnumerable<string> Errors { get; set; } = null!;

        public async Task Register()
        {
            ShowRegistrationErros = false;

            var result = await AuthenticationService.RegisterUser(_userForRegistration);
            if (!result.IsSuccessfulRegistration)
            {
                Errors = result.Errors;
                ShowRegistrationErros = true;
            }
            else
            {
                NavigationManager.NavigateTo("/login");
            }
        }
    }
}