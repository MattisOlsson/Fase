using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;

namespace Fase.Web.Infrastructure
{
    public class Fingerprint
    {
        private readonly IMemoryCache _cache;
        private readonly IHostingEnvironment _env;

        public Fingerprint(IMemoryCache cache, IHostingEnvironment env)
        {
            _cache = cache;
            _env = env;
        }

        public string Tag(string rootRelativePath)
        {
            if (_cache.TryGetValue<string>(rootRelativePath, out var value))
            {
                return value;
            }

            var fileInfo = _env.WebRootFileProvider.GetFileInfo(rootRelativePath);
            var changeToken = _env.WebRootFileProvider.Watch(rootRelativePath);

            var date = File.GetLastWriteTime(fileInfo.PhysicalPath);
            var index = rootRelativePath.LastIndexOf('/');

            var result = rootRelativePath.Insert(index, "/v" + date.Ticks);
            _cache.Set(rootRelativePath, result, changeToken);
            return result;
        }
    }
}