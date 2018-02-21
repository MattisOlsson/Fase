using HtmlAgilityPack;
using System;
using System.IO;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Fase.Web.Controllers
{
    public class ContentEditingModel
    {
        public string File { get; set; }
        public string Html { get; set; }
    }

    public class ContentEditingController : Controller
    {
        [HttpPost, ValidateInput(false)]
        public ActionResult Save()
        {
            var form = Request.Form;
            var fileName = Request.Form["__page__"];
            string html = string.Empty;

            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(fileName)))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    html = streamReader.ReadToEnd();
                }
            }

            foreach (var regionName in Request.Form.AllKeys)
            {
                if (regionName == "__page__")
                {
                    continue;
                }

                var editableRegionValue = Request.Form[regionName];

            }

            return Json(true);
        }
    }
}