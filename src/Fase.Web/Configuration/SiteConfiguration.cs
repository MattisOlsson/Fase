using System.Configuration;

namespace Fase.Web.Configuration
{
    public static class SiteConfiguration
    {
        public static class Postmark
        {
            public static string ApiKey => ConfigurationManager.AppSettings["Postmark:ApiKey"];
            public static string ApiBaseUri => "https://api.postmarkapp.com";
            public static int TimeoutInSeconds => 15;
        }
    }
}