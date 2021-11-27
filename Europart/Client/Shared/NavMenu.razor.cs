
using EuropArt.Domain.Shoppingcarts;
using Microsoft.AspNetCore.Components;
using System;

namespace EuropArt.Client.Shared
{
    public partial class NavMenu : IDisposable
    {
        private bool collapseNavMenu = true;
        [Inject] public Shoppingcart Cart { get; set; }
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
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
    }
}
