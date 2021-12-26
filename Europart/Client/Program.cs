using EuropArt.Client.Artists;
using EuropArt.Client.Artworks;
using EuropArt.Client.Infrastructure;
using EuropArt.Client.Youths;
using EuropArt.Client.Pages.Ordering;
using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using EuropArt.Shared.YouthArtworks;
using EuropArt.Shared.YouthArtists;
using EuropArt.Shared.Accounts;
using EuropArt.Client.Accounts;
using EuropArt.Shared.Users;
using EuropArt.Client.Users;

namespace EuropArt.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IArtworkService, ArtworkService>();
            builder.Services.AddScoped<IArtistService, ArtistService>();
            builder.Services.AddScoped<IYouthArtworkService, YouthArtworkService>();
            builder.Services.AddScoped<IYouthArtistService, YouthArtistService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddHttpClient<StorageService>();
            builder.Services.AddScoped<Shoppingcart>();
            builder.Services.AddHttpClient<StorageService>();
            //private http client for authorized api calls
            builder.Services.AddHttpClient("HooopGalleryAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            //public http client for unauthorized api calls
            builder.Services.AddHttpClient<PublicClient>("PublicHooopGalleryAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HooopGalleryAPI"));
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
            }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();
            /*await builder.Build().RunAsync();*/
            builder.Services.AddLocalization();
            var host = builder.Build();
            CultureInfo culture;
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var result = await js.InvokeAsync<string>("blazorCulture.get");
            if (result != null)
            {
                culture = new CultureInfo(result);
            }
            else
            {
                culture = new CultureInfo("en-US");
                await js.InvokeVoidAsync("blazorCulture.set", "en-US");
            }
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            await host.RunAsync();
        }
    }
}