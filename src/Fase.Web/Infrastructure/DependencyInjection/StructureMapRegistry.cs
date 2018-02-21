using System.Web.Mvc;
using Fase.Web.Configuration;
using Geta.EmailNotification;
using Geta.EmailNotification.Postmark;
using PostmarkDotNet;
using StructureMap;

namespace Fase.Web.Infrastructure.DependencyInjection
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<ViewEngineCollection>().Use(ViewEngines.Engines);
            For<IEmailViewRenderer>().Use<EmailViewRenderer>();
            For<IMailMessageFactory>().Use<MailMessageFactory>();
            For<IEmailNotificationClient>().Use<PostmarkEmailNotificationClient>();
            For<PostmarkClient>().Use(() => new PostmarkClient(SiteConfiguration.Postmark.ApiKey, SiteConfiguration.Postmark.ApiBaseUri, SiteConfiguration.Postmark.TimeoutInSeconds));
        }
    }
}