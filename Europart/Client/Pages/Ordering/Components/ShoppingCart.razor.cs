using EuropArt.Client.Pages.Ordering;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EuropArt.Client.Pages.Ordering.Components
{
    public partial class ShoppingCart
    {
        [Inject] public Shoppingcart Cart { get; set; }
        [Parameter] public int Id { get; set; }
        private IEnumerable<ArtworkDto.Detail> artworks;
        private ArtworkDto.Detail artwork = new();

        private void ConfirmDelete(Item item)
        {
            Cart.RemoveItem(item);
        }


        private void RequestDelete(Item item)
        {
            item.RequestingDelete = true;
        }
        private void CancelRequestDelete(Item item)
        {
            item.RequestingDelete = false;
        }
    }
}
