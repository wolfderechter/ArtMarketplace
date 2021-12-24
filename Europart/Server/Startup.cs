using EuropArt.Services.Artists;
using EuropArt.Services.Artworks;
using EuropArt.Services.Infrastructure;
using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using EuropArt.Persistence.Data;
using System.Data.SqlClient;
using System.Linq;
using EuropArt.Shared.YouthArtworks;
using EuropArt.Services.Youths;
using EuropArt.Shared.YouthArtists;
using EuropArt.Shared.Accounts;
using EuropArt.Services.Accounts;

namespace EuropArt.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("HooopDb"));
        //  services.AddDbContext<HooopDbContext>(options => options.UseSqlServer(builder.ConnectionString).EnableSensitiveDataLogging(Configuration.GetValue<bool>("Logging:EnableSqlParameterLogging")));

            services.AddDbContextPool<HooopDbContext>(options => options.UseMySql(builder.ConnectionString, ServerVersion.AutoDetect(builder.ConnectionString)));

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => $"{x.DeclaringType.Name}.{x.Name}");
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hooop Gallery API", Version = "v1" });
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddRazorPages();
            services.AddScoped<IArtworkService, ArtworkService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IYouthArtworkService, YouthArtworkService>();
            services.AddScoped<IYouthArtistService, YouthArtistService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IStorageService, BlobStorageService>();

            services.AddScoped<HooopDataInitializer>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Authority"];
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });
        }

        private RequestLocalizationOptions GetLocalizationOptions()
        {
            var cultures = Configuration.GetSection("Cultures").GetChildren().ToDictionary(x => x.Key, x => x.Value);
            var supportedCultures = cultures.Keys.ToArray();
            var localizationOptions = new RequestLocalizationOptions().AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
            return localizationOptions;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HooopDataInitializer dataInitializer, HooopDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hooop Gallery API"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            dataInitializer.SeedData();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            //app.UseRequestLocalization(GetLocalizationOptions());
            app.UseRequestLocalization(new RequestLocalizationOptions()
                .AddSupportedCultures(new[] { "en-US", "es-CL" })
                .AddSupportedUICultures(new[] { "en-US", "es-CL" }));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
