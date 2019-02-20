using Piranha.AspNetCore.Services;
using Piranha.Models;

namespace Fase.Web.Extensions
{
    public static class SitemapExtensions
    {
        public static bool IsSelected(this SitemapItem item, IApplicationService webApp)
        {
            return item.Id == webApp.PageId || webApp.Url.StartsWith(item.Permalink);
        }
    }
}