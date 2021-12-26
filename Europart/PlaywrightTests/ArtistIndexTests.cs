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
    public class ArtistIndexTests : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";

        [Test]
        public async Task Show_ArtworkIndex_With_4_Items_On_Load()
        {
            await Page.GotoAsync($"{ServerBaseUrl}/artist");
            await Page.WaitForSelectorAsync("data-test-id=artist-item");
            var amountOfProducts = await Page.Locator("data-test-id=artist-item").CountAsync();
            amountOfProducts.ShouldBe(4);
        }


        [Test]
        public async Task SettingSearch_FiltersArtworks()
        {
            var searchterm = "Wolf De Rechter";
            //navigate to the artwork index page
            await Page.GotoAsync($"{ServerBaseUrl}/artist");

            //wait untill the page is fully loaded / h1 title is loaded
            await Page.WaitForSelectorAsync("data-test-id=artist-item");

            //click on...
            await Page.ClickAsync("data-test-id=search-input");
            await Page.FillAsync("data-test-id=search-input", searchterm);
            await Page.PressAsync("data-test-id=search-input", "Enter");

            //wait to filter
            await Task.Delay(100);

            //Assert
            var nameString = Page.TextContentAsync("data-test-id=artist-item-name").Result;
            nameString.ShouldBe(searchterm);
        }
    }
}