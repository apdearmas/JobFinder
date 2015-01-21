using System.Net;
using System.Net.Mail;

namespace BDL
{
    public class SmtpClientWrapper : ISmtpClientWrapper
    {
        private SmtpClient smtpClient;
        private MailMessage mail;

        const int SmtpPort = 587;
        const string Host = "plus.smtp.mail.yahoo.com";
        const string MailFrom = "fgongora67@yahoo.com";
        const string Password = "Gabriela01";

        public SmtpClientWrapper()
        {
            smtpClient = new SmtpClient(Host)
            {
                Port = SmtpPort,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(MailFrom, Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
        }

        public void Send(string targetEmail, string subject, string message)
        {
            mail = new MailMessage
            {
                From = new MailAddress(MailFrom),
                Subject = subject,
                Body = message,
            };
            mail.To.Add(targetEmail);

            smtpClient.Send(mail);
        }
    }
}

