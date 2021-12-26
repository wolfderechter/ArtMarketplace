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
    public class ArtistDetailTests : PageTest
    {
        private const string ServerBaseUrl = "https://localhost:5001";

        [Test]
        public async Task Show_ArtistDetail_OnLoad()
        {
            await Page.GotoAsync($"{ServerBaseUrl}/artist/1");
            await Page.WaitForSelectorAsync("data-test-id=artist-detail-name");
            var artistName = await Page.TextContentAsync("data-test-id=artist-detail-name");
            artistName.ShouldNotBeEmpty();
        }
        
        [Test]
        public async Task ArtistDetail_Edit_ChangesArtistDetail()
        {
            //login
            await Page.GotoAsync($"{ServerBaseUrl}/authentication/login");
            await Task.Delay(16000);
            await Page.FillAsync("input[name='email']", "wolf.derechter@student.hogent.be");
            await Page.FillAsync("input[name='password']", "Paswoord1");
            await Page.ClickAsync("button[name='submit']");
            await Task.Delay(7000);

            var editBiography = "Nieuwe beschrijving";

            await Page.GotoAsync($"{ServerBaseUrl}/artist/edit/1");

            await Page.FillAsync("data-test-id=artist-biography-input", editBiography);
            await Page.ClickAsync("data-test-id=edit-button");
            await Task.Delay(3000);

            await Page.GotoAsync($"{ServerBaseUrl}/artist/1");
            await Page.WaitForSelectorAsync("data-test-id=artist-detail-biography");
            var artistDescription = await Page.TextContentAsync("data-test-id=artist-detail-biography");
            artistDescription.ShouldBe(editBiography);
        }        
        [Test]
        public async Task ArtistDetail_Edit_NoFirstName_IsInvalid()
        {
            //login
            await Page.GotoAsync($"{ServerBaseUrl}/authentication/login");
            await Task.Delay(16000);
            await Page.FillAsync("input[name='email']", "wolf.derechter@student.hogent.be");
            await Page.FillAsync("input[name='password']", "Paswoord1");
            await Page.ClickAsync("button[name='submit']");
            await Task.Delay(7000);


            await Page.GotoAsync($"{ServerBaseUrl}/artist/edit/1");

            await Page.FillAsync("data-test-id=artist-detail-firstname-input", " ");
            await Page.ClickAsync("data-test-id=edit-button");
            await Task.Delay(500);

            var error = Page.Locator("data-test-id=artist-detail-firstname-error").TextContentAsync()?.Result;
            error.ShouldNotBeEmpty();
        }
    }
}
