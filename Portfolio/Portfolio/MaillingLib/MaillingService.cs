using System;
using System.Net;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Portfolio.Models;

namespace Portfolio.MaillingLib
{
    public class MailingService
    {
        private string emailToAddress1 { get; set; }
        private string emailToAddress2 { get; set; }
        private string emailToAddress3 { get; set; }
        private string emailSubject = "An email sent from your Portfolio website";

        private string smtpServer { get; set; }
        private int smtpPort { get; set; }
        private string smtpUserName { get; set; }
        private string smtpPassword { get; set; }
        private string gmailClientID { get; set; }
        private string gmailClientSecret { get; set; }

        public string Error { get; set; }

        public MailingService(IConfiguration configuration)
        {
            this.emailToAddress1 = configuration["MaillingSettings:EmailTo1"];
            this.emailToAddress2 = configuration["MaillingSettings:EmailTo2"];
            this.emailToAddress3 = configuration["MaillingSettings:EmailTo3"];
            this.smtpServer = configuration["MaillingSettings:SmtpServer"];
            this.smtpPort = int.Parse(configuration["MaillingSettings:SmtpPort"].ToString());
            this.smtpUserName = configuration["MaillingSettings:SmtpUserName"];
            this.smtpPassword = configuration["MaillingSettings:SmtpPassword"];
            this.gmailClientID = configuration["MaillingSettings:GMailClientID"];
            this.gmailClientSecret = configuration["MaillingSettings:GMailClientSecret"];
        }

        public async System.Threading.Tasks.Task<bool> SendAsync(Message message)
        {
            try
            {
                var myMail = new MimeMessage();
                myMail.To.Add(MailboxAddress.Parse(emailToAddress1));
                myMail.To.Add(MailboxAddress.Parse(emailToAddress2));
                myMail.To.Add(MailboxAddress.Parse(emailToAddress3));
                myMail.From.Add(MailboxAddress.Parse(smtpUserName));

                myMail.Subject = emailSubject;
                //We will say we are sending HTML. But there are options for plaintext etc. 
                myMail.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<p>Hi, this is " + message.Gender + " " + message.FirstName + " " + message.LastName + "</p>"
                            + "<br />"
                            + "<p>" + message.ExtraComment + "</p>"
                            + "<br />"
                            + "<p>My Mobile: " + message.Mobile + "</p>"
                            + "<p>My Email: " + message.Email + "</p>"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, smtpPort, SecureSocketOptions.StartTls);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(smtpUserName, smtpPassword);

                    await client.SendAsync(myMail);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception err)
            {
                Error = err.Message + "\n" + err.Source;
                return false;
            }
        }
    }
}
