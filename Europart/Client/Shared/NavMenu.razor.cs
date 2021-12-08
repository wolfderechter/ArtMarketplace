using EuropArt.Client.Pages.Ordering;
using Microsoft.AspNetCore.Components;
using System;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace EuropArt.Client.Shared
{
    public partial class NavMenu : IDisposable
    {
        private bool collapseNavMenu = false;
        [Inject] public Shoppingcart Cart { get; set; }
        private string baseMenuClass = "navbar-collapse ";
        private string NavMenuCssClass =>(collapseNavMenu ? " collapse" : "");
        private bool show = false;

        private void ToggleNavMenu()
        {
            Console.WriteLine("Navmenu toggled!");
            collapseNavMenu = !collapseNavMenu;
        }

        private void Search(ChangeEventArgs args)
        {
            NavigationManager.NavigateTo("/artwork");
        }

        private void OpenShoppingCart()
        {
            NavigationManager.NavigateTo("/shoppingcart");
        }

        protected override void OnInitialized()
        {
            Cart.OnCartChanged += StateHasChanged;
        }

        public void Dispose()
        {
            Cart.OnCartChanged -= StateHasChanged;
        }

        public void ToggleAccountDropdown()
        {
            collapseNavMenu = !collapseNavMenu;
            show = !show;
        }

        private void BeginSignOut()
        {
            ToggleAccountDropdown();
            SignOutManager.SetSignOutState();
            NavigationManager.NavigateTo("authentication/logout");
        }
    }
}
