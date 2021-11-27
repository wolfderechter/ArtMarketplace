using EuropArt.Domain.Shoppingcarts;
using Microsoft.AspNetCore.Components;

namespace EuropArt.Client.Pages
{
    public partial class ShoppingCart
    {
        [Inject] public Shoppingcart Cart { get; set; }
    }
}
