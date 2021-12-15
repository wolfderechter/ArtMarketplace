using Microsoft.AspNetCore.Components;

namespace EuropArt.Client.Artworks
{
    public partial class ArtworkPager
    {
        private bool hasNoMorePrevious => Filter.Page == 0;
        private bool hasNoMoreNext => (Filter.Page + 1) * Filter.Amount >= TotalAmount;
        [Parameter] public ArtworkFilter Filter { get; set; }
        [Parameter] public int TotalAmount { get; set; }

        private void GoToPrevious()
        {
            if (hasNoMorePrevious)
                return;

            Filter.Page--;
        }

        private void GoToNext()
        {
            if (hasNoMoreNext)
                return;

            Filter.Page++;

        }
    }
}
