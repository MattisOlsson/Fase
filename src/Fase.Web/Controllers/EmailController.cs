using System;
using System.Linq;
using System.Threading.Tasks;
using Fase.Web.Models;
using Fase.Web.Models.FormModels;
using Geta.EmailNotification.AspNetCore;
using Geta.EmailNotification.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Fase.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IAsyncEmailNotificationClient _emailNotificationClient;
        private readonly IEmailNotificationRequestFactory _emailNotificationRequestFactory;

        public EmailController(IAsyncEmailNotificationClient emailNotificationClient, IEmailNotificationRequestFactory emailNotificationRequestFactory)
        {
            _emailNotificationClient = emailNotificationClient;
            _emailNotificationRequestFactory = emailNotificationRequestFactory;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(EmailForm model)
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

            try
            {
                var email = _emailNotificationRequestFactory.CreateEmailBuilder()
                    .WithFrom("mattias@geta.no")
                    .WithTo("info@fase-ab.se")
                    .WithSubject(model.Subject)
                    .WithViewName("Contact")
                    .WithViewModel(model)
                    .Build();

                var emailResponse = await _emailNotificationClient.SendAsync(email);

                response.Success = emailResponse.IsSent;
                response.Data = model;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.Message = exc.Message;
            }

            return Json(response);
        }
    }
}