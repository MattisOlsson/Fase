using System;
using Fase.Web.Extensions;
using Fase.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;
using Piranha.Extend.Blocks;

namespace Fase.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config => 
            {
                config.ModelBinderProviders.Insert(0, new Piranha.Manager.Binders.AbstractModelBinderProvider());
            });
            services.AddPiranhaApplication();
            services.AddPiranhaFileStorage();
            services.AddPiranhaImageSharp();
            services.AddPiranhaEF(options => options.UseSqlite("Filename=./piranha.db"));
            services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options => options.UseSqlite("Filename=./piranha.db"));
            services.AddPiranhaManager();
            services.AddPiranhaMemCache();
            services.AddPostmark(_configuration);
            services.AddMemoryCache();
            services.AddScoped<Fingerprint>();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services, IApi api)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Initialize Piranha
            App.Init();

            // Configure cache level
            App.CacheLevel = Piranha.Cache.CacheLevel.Basic;

            // Add custom media types
            App.MediaTypes.Videos.Add(".webm", "video/webm");

            // Register select fields
            App.Fields.RegisterSelect<Models.ButtonCssClass>();
            App.Fields.RegisterSelect<Models.TextBlockCssClass>();
            App.Fields.RegisterSelect<Models.HeroCssClass>();

            // Register custom blocks
            App.Blocks.Register<Models.Blocks.TextAndImageBlock>();
            App.Blocks.Register<Models.Blocks.PartnersBlock>();
            App.Blocks.Register<Models.Blocks.ArtistsBlock>();
            App.Blocks.Register<Models.Blocks.TeaserBlock>();
            App.Blocks.Register<Models.Blocks.SignupBlock>();

            // Remove unwanted blocks
            App.Blocks.UnRegister<HtmlBlock>();
            App.Blocks.UnRegister<TextBlock>();

            // Add manager resources
            var managerModule = App.Modules.Get<Piranha.Manager.Module>();
            managerModule.Styles.Add("~/public/manager.css");
            managerModule.Styles.Add("https://fonts.googleapis.com/css?family=Arizonia|Roboto:400,400i,700,700i");
            managerModule.Scripts.Add("~/public/manager.js");

            // Build content types
            var pageTypeBuilder = new Piranha.AttributeBuilder.PageTypeBuilder(api)
                .AddType(typeof(Models.StandardPage))
                .AddType(typeof(Models.StartPage))
                .AddType(typeof(Models.PartnersPage))
                .AddType(typeof(Models.EventListingPage))
                .AddType(typeof(Models.EventPage))
                .AddType(typeof(Models.ArtistListingPage));
            pageTypeBuilder.Build()
                .DeleteOrphans();

            if (env.IsProduction())
            {
            }

            // Register middleware
            app.UseRedirects(_configuration);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UsePiranha();
            app.UsePiranhaManager();
            app.UsePiranhaSitemap();
            app.UseMvc(routes => 
            {
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
