using Fox.Models;
using Fox.Tools.Interfaces;
using System.Net.Mail;

namespace Fox.Tools
{
    public class EmailSender : IEmailSender
    {
        public void Send(string to, string body, SmtpConfiguration smtp)
        {
            var message = new MailMessage(smtp.EmailAddress, to);
            message.Subject = "Hardware Temperature Information";
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Host = smtp.SmtpServer;
            client.Credentials = new System.Net.NetworkCredential(smtp.UserName, smtp.Password);
            client.Send(message);
        }
    }
}
