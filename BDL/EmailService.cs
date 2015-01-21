<<<<<<< HEAD
<<<<<<< HEAD
﻿namespace BDL
{
    public class EmailService : IEmailService
    {
        public void Send(string targetEmail, string subject, string message)
        {
        }
    }
}
=======
=======
>>>>>>> master
﻿using BDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace BDL
{
    public class EmailService : IEmailService
    {
        public SmtpClient smtpClient;
        public MailMessage mail;

        const int       SmtpPort =      587;
        const string    Host =         "plus.smtp.mail.yahoo.com";
        const string    MailFrom =     "fgongora67@yahoo.com";
        const string    Password =     "Gabriela01";
       
        

        public EmailService()
        {
            ConfigureSmtpClient();
            ConfigureMail();

        }
                

        private void ConfigureMail()
        {
            mail = new MailMessage();
            mail.From = new MailAddress(EmailService.MailFrom);

        }

        private void ConfigureSmtpClient()
        {
            smtpClient = new SmtpClient(Host);
            smtpClient.Port = SmtpPort;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(EmailService.MailFrom, EmailService.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
        }

        public void Send(string targetEmail, string subject, string message)
        {
            mail.To.Add(targetEmail);
            mail.Subject = subject;
            mail.Body = message;

            smtpClient.Send(mail);
           
        }
        
    }
}
<<<<<<< HEAD
>>>>>>> Added business logic to send email.
=======
>>>>>>> master
