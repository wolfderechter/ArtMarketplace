using EuropArt.Client.Infrastructure;
using EuropArt.Shared.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EuropArt.Client.Pages.RegisterPages
{
    partial class UserRegistration
    {
        private readonly IConfiguration _config;
        UserDto.Create newUser = new() { };
        [Inject] private IUserService userService { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private AuthenticationStateProvider auth { get; set; }
        public string domain { get; } = "https://dev-ixi3mmyx.eu.auth0.com";
        [Parameter] public string AuthId { get; set; }
        [Parameter] public string state { get; set; }
        [Inject] private PublicClient publicClient { get; set; }
        public UserRegistration()
        {

        }
        public UserRegistration(IConfiguration config)
        {
            _config = config;
        }
        public async Task SignUpAsync()
        {
            newUser.DateCreated = DateTime.Now;
            newUser.AuthId = AuthId;
            UserRequest.Create request = new()
            {
                User = newUser

            };
            var response = await userService.CreateAsync(request);
            if (response != null)
            {
                navigationManager.NavigateTo(domain + "/continue?state=" + state); 
            }
        }
    }
}
