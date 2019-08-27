using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using WebGUI.Infrastructure;

namespace WebGUI
{
    public class IdentityConfig : IIdentityMessageService
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseGoogleAuthentication(
                clientId: "947405897069-hsr34visbsq0jjr70717c8ucdjnuqp01.apps.googleusercontent.com",
                clientSecret: "ohDcNA41drBwd49Ks8obprz1");
            app.UseFacebookAuthentication(
                appId: "538596996508815",
                appSecret: "84616cc98450d0ecd0779bd6175a6b3b");
        }
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSendGridasync(message);
        }
        private async Task ConfigSendGridasync(IdentityMessage message)
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("wizaredfamily@gmail.com", "Math.com");
            var subject = message.Subject;
            EmailAddress to = new EmailAddress(message.Destination);
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}