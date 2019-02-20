using Fase.Web.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;

namespace Fase.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseRedirects(this IApplicationBuilder app, IConfiguration configuration)
        {
            var redirectSection = configuration.GetSection(nameof(RedirectSettings));
            var redirectSettings = redirectSection.Get<RedirectSettings>();

            if (!redirectSettings.Enabled)
            {
                return;
            }

            var options = new RewriteOptions();

            foreach (var redirect in redirectSettings.Redirects)
            {
                options = options.AddRedirect(redirect.From, redirect.To, (int)redirect.StatusCode);
            }

            // Fingerprint
            options = options.AddRewrite("([\\S]+)(/v-[0-9]+/)([\\S]+)", "$1/$3", true);

            app.UseRewriter(options);
        }
    }
}