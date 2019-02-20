using System;
using System.Linq;
using System.Threading.Tasks;
using Fase.Web.Extensions;
using Fase.Web.Models;
using Fase.Web.Models.FormModels;
using Microsoft.AspNetCore.Mvc;
using PostmarkDotNet;

namespace Fase.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly PostmarkClient _postmarkClient;

        public EmailController(PostmarkClient postmarkClient)
        {
            _postmarkClient = postmarkClient;
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
                var message = new PostmarkMessage
                {
                    From = "mattias@geta.no",
                    To = "info@fase-ab.se",
                    Subject = model.Subject,
                    HtmlBody = await this.RenderViewToStringAsync("~/Views/Emails/Contact.cshtml", model)
                };

                var postmarkResponse = await _postmarkClient.SendMessageAsync(message);
                response.Success = postmarkResponse.Status == PostmarkStatus.Success;
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