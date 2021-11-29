﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Client.Artists
{
    public class ArtistFilter
    {
        public event Action OnArtworkFilterChanged;
        private string searchterm;

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
    }
}
