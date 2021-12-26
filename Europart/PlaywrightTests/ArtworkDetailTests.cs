using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    public class ArtworkDetailTests : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";

        [Test]
        public async Task Show_ArtworkDetail_OnLoad()
        {
            await Page.GotoAsync($"{ServerBaseUrl}/artwork/5");
            await Page.WaitForSelectorAsync("data-test-id=artwork-detail-name");
            var artworkName = await Page.TextContentAsync("data-test-id=artwork-detail-name");
            artworkName.ShouldNotBeEmpty();
        }
        [Test]
        public async Task ArtworkDetail_AddToShoppingcart_IncreasesShoppingcartCounter()
        {
            await Page.GotoAsync($"{ServerBaseUrl}/artwork/5");
            await Page.WaitForSelectorAsync("data-test-id=artwork-detail-name");

            await Page.ClickAsync("data-test-id=addtoshoppingcart-button");

            var shoppingCartCounter = await Page.TextContentAsync("data-test-id=shoppingcart-counter");
            shoppingCartCounter.ShouldBe("1");
        }

        [Test]
        public async Task ArtistDetail_Edit_ChangesArtistDetail()
        {
            //login
            await Page.GotoAsync($"{ServerBaseUrl}/authentication/login");
            await Page.FillAsync("input[name='email']", "wolf.derechter@student.hogent.be");
            await Page.FillAsync("input[name='password']", "Paswoord1");
            await Page.ClickAsync("text=submit");

            var editTitle = "Boom";

            await Page.GotoAsync($"{ServerBaseUrl}/artwork/3");
            await Page.ClickAsync("data-test-id=edit-button");

            await Page.FillAsync("data-test-id=artwork-name-input", editTitle);

            await Page.WaitForSelectorAsync("data-test-id=artist-detail-name");
            var artistName = await Page.TextContentAsync("data-test-id=artist-detail-name");
            artistName.ShouldBe(editTitle);
        }
    }
}
