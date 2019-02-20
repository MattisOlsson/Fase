using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Fase.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var env = builderContext.HostingEnvironment;

                    config
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile("redirects.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"redirects.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .UseStartup<Startup>()
                .Build();
    }
}
