using Microsoft.AspNet.Identity;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebGUI.Models;

namespace WebGUI.Repository.Concreate
{
    public class MailConfirmation : IMailConfirmation
    {
        readonly EmailSettings EmailSettings = new EmailSettings();
        public async Task SendMessage(IdentityMessage message)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.EnableSsl = EmailSettings.UseSsl;
                        smtpClient.Host = EmailSettings.ServerName;
                        smtpClient.Port = EmailSettings.ServerPort;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new
                            NetworkCredential(EmailSettings.Username, EmailSettings.Password);
                        MailMessage mailMessage = new MailMessage(
                            EmailSettings.MailFromAddress
                            , message.Destination
                            , message.Subject
                            , message.Body)
                        {
                            IsBodyHtml = true
                        };
                        smtpClient.Send(mailMessage);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            });
        }
    }
}