using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using Portfolio.Models;

namespace Portfolio.MaillingLib
{
    public class MailingService
    {
        private string emailFromAddress { get; set; }
        private string emailPassword { get; set; }
        private string emailToAddress1 { get; set; }
        private string emailToAddress2 { get; set; }
        private string emailToAddress3 { get; set; }
        private string emailSubject = "An email sent from your Portfolio website";

        public string Error { get; set; }


        public MailingService(IConfiguration configuration)
        {
            this.emailFromAddress = configuration["MaillingSettings:FromAddress"];
            this.emailPassword = configuration["MaillingSettings:pwd"];
            this.emailToAddress1 = configuration["MaillingSettings:EmailTo1"];
            this.emailToAddress2 = configuration["MaillingSettings:EmailTo2"];
            this.emailToAddress3 = configuration["MaillingSettings:EmailTo3"];
        }

        public bool Sending(Message message)
        {
            try
            {
                MailMessage myMail = new MailMessage();
                myMail.From = new MailAddress(emailFromAddress);
                myMail.To.Add(new MailAddress(emailToAddress1));
                myMail.To.Add(new MailAddress(emailToAddress2));
                myMail.To.Add(new MailAddress(emailToAddress3));
                myMail.Subject = emailSubject;
                myMail.SubjectEncoding = Encoding.UTF8;

                myMail.Body = "Hi, this is " + message.Gender + " " + message.FirstName + " " + message.LastName + ".\n\n"
                              + message.ExtraComment + ".\n\n"
                              + "My Email: " + message.Email +"\n"
                              + "My Mobile: " + message.Mobile + "\n";
                myMail.BodyEncoding = Encoding.UTF8;
                myMail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;                    //Gmail smtp port
                smtp.Credentials = new NetworkCredential(emailFromAddress, emailPassword);
                smtp.EnableSsl = true;              //Gmail SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //Gmail: declear sending through network

                smtp.Send(myMail);
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
