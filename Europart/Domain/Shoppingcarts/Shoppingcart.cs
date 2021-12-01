using System;
using System.Collections.Generic;
using System.Linq;

namespace EuropArt.Domain.Shoppingcarts
{
    public class Shoppingcart
    {
        private List<Item> items = new();
        public IList<Item> Items => items;

        public event Action OnCartChanged;
        public void NotifyCartChanged() => OnCartChanged?.Invoke();

        public void AddItem(int artworkId, string name, decimal price,string imagePath)
        {
            var existingItem = items.SingleOrDefault(x => x.ArtworkId == artworkId);

            if (existingItem == null)
            {
                Item item = new Item(artworkId, name, price, imagePath);
                items.Add(item);
            }
            NotifyCartChanged();
          
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
            NotifyCartChanged();
        }
    }

    public class Item
    {
        public int ArtworkId { get; init; }
        public decimal Price { get; init; }
        public string Name { get; init; }
        public string ImagePath { get; set; }
        public bool RequestingDelete { get; set; }

        public Item(int artworkId, string name, decimal price, string imagepath)
        {
            ArtworkId = artworkId;
            Name = name;
            Price = price;
            ImagePath = imagepath;
        }
    }
}
