using Fase.Web.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace Fase.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseRedirects(this IApplicationBuilder app, IConfiguration configuration)
        {
            var redirectSection = configuration.GetSection(nameof(RedirectSettings));
            var redirectSettings = redirectSection.Get<RedirectSettings>();

            var options = new RewriteOptions();

            if (redirectSettings.Enabled)
            {
                foreach (var redirect in redirectSettings.Redirects)
                {
                    options = options.AddRedirect(redirect.From, redirect.To, (int)redirect.StatusCode);
                }
            }

            // Fingerprint rewrite
            options = options.AddRewrite("([\\S]+)(/v[0-9]+/)([\\S]+)", "$1/$3", false);

            app.UseRewriter(options);
        }

        public static void UseStaticFilesWithCaching(this IApplicationBuilder app, IHostingEnvironment env)
        {
            // Add mime type for .webmanifest
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            contentTypeProvider.Mappings[".webmanifest"] = "application/manifest+json";

            // Configure static cache period
            var cachePeriod = env.IsDevelopment() ? "600" : "604800";

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                },
                ContentTypeProvider = contentTypeProvider
            });
        }
    }
}