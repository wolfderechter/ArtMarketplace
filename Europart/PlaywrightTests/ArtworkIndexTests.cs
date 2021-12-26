using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;
using System;
using System.Threading.Tasks;

namespace EuropArt.PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    public class ArtworkIndexTests : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";

        [Test]
        public async Task Show_ArtworkIndex_With_25_Items_On_Load()
        {
            await Page.GotoAsync($"{ServerBaseUrl}/artwork");
            await Page.WaitForSelectorAsync("data-test-id=artwork-item");
            var amountOfArtworks = await Page.Locator("data-test-id=artwork-item").CountAsync();
            amountOfArtworks.ShouldBe(25);
        }

        [Test]
        public async Task SettingArtworksFilter_FiltersArtworks()
        {
            //navigate to the artwork index page
            await Page.GotoAsync($"{ServerBaseUrl}/artwork");

            //wait untill the page is fully loaded / h1 title is loaded
            await Page.WaitForSelectorAsync("data-test-id=artwork-item");

            //click on...
            await Page.ClickAsync("data-test-id=show-filters-button");
            await Page.ClickAsync("data-test-id=minimumprice-input");
            await Page.FillAsync("data-test-id=minimumprice-input", "15");
            await Page.PressAsync("data-test-id=minimumprice-input", "Enter");

            //wait to filter
            await Task.Delay(100);

            //Assert
            var priceString = Page.TextContentAsync("data-test-id=artwork-item-price").Result.Substring(1);
            priceString = priceString.Substring(0, priceString.IndexOf('.'));
            var price = Convert.ToDecimal(priceString);
            price.ShouldBeGreaterThanOrEqualTo(15M);
        }

        [Test]
        public async Task SettingSearch_FiltersArtworks()
        {
            var searchterm = "Stoel";
            //navigate to the artwork index page
            await Page.GotoAsync($"{ServerBaseUrl}/artwork");

            //wait untill the page is fully loaded / h1 title is loaded
            await Page.WaitForSelectorAsync("data-test-id=artwork-item");

            //click on...
            await Page.ClickAsync("data-test-id=search-input");
            await Page.FillAsync("data-test-id=search-input", searchterm);
            await Page.PressAsync("data-test-id=search-input", "Enter");

            //wait to filter
            await Task.Delay(100);

            //Assert
            var nameString = Page.TextContentAsync("data-test-id=artwork-item-name").Result;
            nameString.ShouldBe(searchterm);
        }


        [Test]
        public async Task SettingArtworksOrderByPriceDescending_FiltersArtworksByPriceDescending()
        {
            //navigate to the artwork index page
            await Page.GotoAsync($"{ServerBaseUrl}/artwork");

            //wait untill the page is fully loaded / h1 title is loaded
            await Page.WaitForSelectorAsync("data-test-id=artwork-item");

            //click on...
            await Page.SelectOptionAsync("data-test-id=orderby-select", "OrderByPriceDescending");

            //wait to filter
            await Task.Delay(100);

            //get first 2 prices of artworks
            var prices = Page.QuerySelectorAllAsync("data-test-id=artwork-item-price").Result;
            var priceString1 = prices[0].ToString().Substring(prices[0].ToString().IndexOf('$'));
            priceString1 = priceString1.Substring(1, priceString1.IndexOf('.'));
            var price1 = Convert.ToDecimal(priceString1);

            var priceString2 = prices[1].ToString().Substring(prices[1].ToString().IndexOf('$'));
            priceString2 = priceString2.Substring(1, priceString2.IndexOf('.'));
            var price2 = Convert.ToDecimal(priceString2);

            price1.ShouldBeGreaterThanOrEqualTo(price2);
        }
    }
}

