using Fase.Web.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostmarkDotNet;

namespace Fase.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPostmark(this IServiceCollection services, IConfiguration configuration)
        {
            var postmarkSection = configuration.GetSection(nameof(PostmarkSettings));
            var settings = postmarkSection.Get<PostmarkSettings>();
            services.AddTransient(provider => new PostmarkClient(settings.SecretKey));
        }
    }
}