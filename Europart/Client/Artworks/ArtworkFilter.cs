using EuropArt.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Client.Artworks
{
    public class ArtworkFilter
    {
        public event Action OnArtworkFilterChanged;
        private string searchterm;
        private decimal? minimumPrice;
        private decimal? maximumPrice;
        private bool includingAuctions;
        private string category;
        private string style;
        private OrderByArtwork orderBy;
        private void NotifyStateChanged() => OnArtworkFilterChanged.Invoke();

        public string Searchterm
        {
            get => searchterm;
            set
            {
                searchterm = value;
                NotifyStateChanged();
            }
        }
        public decimal? MinimumPrice
        {
            get => minimumPrice;
            set
            {
                minimumPrice = value;
                NotifyStateChanged();
            }
        }        
        public decimal? MaximumPrice
        {
            get => maximumPrice;
            set
            {
                maximumPrice = value;
                NotifyStateChanged();
            }
        }

        public bool IncludingAuctions
        {
            get => includingAuctions;
            set
            {
                includingAuctions = value;
                NotifyStateChanged();
            }
        }
        public string Category
        {
            get => category;
            set
            {
                category = value;
                NotifyStateChanged();
            }
        }        
        public string Style
        {
            get => style;
            set
            {
                style = value;
                NotifyStateChanged();
            }
        }
        public OrderByArtwork OrderBy
        {
            get => orderBy;
            set
            {
                orderBy = value;
                NotifyStateChanged();
            }
        }
    }
}
