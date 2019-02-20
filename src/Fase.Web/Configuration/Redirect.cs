using System.Net;

namespace Fase.Web.Configuration
{
    public class Redirect
    {
        public Redirect()
        {
            StatusCode = HttpStatusCode.Redirect;
        }

        public string From { get; set; }
        public string To { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}