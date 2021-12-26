using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace EuropArt.PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    public class HomeTests : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";

        [Test]
        public async Task Show_Home_With_6_Artworks_On_Load()
        {
            await Page.GotoAsync(ServerBaseUrl);
            await Page.WaitForSelectorAsync("data-test-id=artworks1");
            await Page.WaitForSelectorAsync("data-test-id=artworks2");
            var amountOfArtworks = await Page.Locator("data-test-id=artwork-item").CountAsync();
            amountOfArtworks.ShouldBe(6);
        }

        [Test]
        public async Task Show_Home_With_3_Artists_On_Load()
        {
            await Page.GotoAsync(ServerBaseUrl);
            await Page.WaitForSelectorAsync("data-test-id=artists");
            var amountOfArtists = await Page.Locator("data-test-id=artist-item").CountAsync();
            amountOfArtists.ShouldBe(3);
        }
    }
}