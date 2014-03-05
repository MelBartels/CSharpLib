using System.Net;
using System.Net.Mail;

namespace GenLib.Email
{
    public class Gmail
    {
        public void Send(string username, string password, string gmailAddress, string toEmailAddress, string subject, string body)
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(gmailAddress);
            mail.To.Add(toEmailAddress);
            mail.Subject = subject;
            mail.Body = body;

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential(username, password);
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
        }
    }
}