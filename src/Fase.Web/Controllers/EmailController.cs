using System;
using System.Linq;
using System.Web.Mvc;
using Fase.Web.Models;
using Geta.EmailNotification;

namespace Fase.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailNotificationClient _emailNotificationClient;

        public EmailController(IEmailNotificationClient emailNotificationClient)
        {
            _emailNotificationClient = emailNotificationClient ?? throw new ArgumentNullException(nameof(emailNotificationClient));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(ContactFormModel model)
        {
            var response = new SendEmailResponse();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Data = ModelState.Keys
                    .Where(x => ModelState[x].Errors.Count > 0)
                    .Select(x => new
                    {
                        Name = x,
                        Errors = ModelState[x].Errors.Select(y => y.ErrorMessage)
                    });

                return Json(response);
            }

            var email = new EmailNotificationRequestBuilder()
                .WithFrom("mattias@geta.no")
                .WithTo("info@fase-ab.se")
                .WithSubject(model.Subject)
                .WithViewData("Model", model)
                .WithViewName("Contact")
                .Build();

            try
            {
                _emailNotificationClient.Send(email);
                response.Success = true;
                response.Data = model;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.Message = exc.Message;
            }

            return Json(response);
        }

        public ActionResult Contact()
        {
            var model = new EmailNotificationRequestBuilder()
                .WithFrom("mattias@geta.no")
                .WithTo("mattis.olsson@gmail.com")
                .WithSubject("Test")
                .WithViewData("Model", new ContactFormModel())
                .Build();

            ViewData["Model"] = new ContactFormModel();

            return View(model);
        }
    }
}