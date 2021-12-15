using EuropArt.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Client.Artists
{
    public class ArtistFilter
    {
        public event Action OnArtworkFilterChanged;
        private string searchterm;
        private OrderByArtist orderBy;
        private void NotifyStateChanged() => OnArtworkFilterChanged.Invoke();
        private int page;
        private int amount = 25;

        public string Searchterm
        {
            get => searchterm;
            set
            {
                searchterm = value;
                NotifyStateChanged();
            }
        }
        public OrderByArtist OrderBy
        {
            get => orderBy;
            set
            {
                orderBy = value;
                NotifyStateChanged();
            }
        }

        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                NotifyStateChanged();
            }
        }

        public int Page
        {
            get => page;
            set
            {
                page = value;
                NotifyStateChanged();
            }
        }
    }
}
