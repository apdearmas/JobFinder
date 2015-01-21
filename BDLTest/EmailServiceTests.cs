using BDL;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BDLTest
{
    public class EmailServiceTests
    {
        private EmailService emailService;

        public EmailServiceTests()
        {
            emailService = new EmailService();
        }
        [Fact]       
        public void CreateEmailServiceObject()
        {          
            Assert.IsNotNull(emailService);
        }

        [Fact]
        public void CreateSmtpClientObject()
        {
            Assert.IsNotNull(emailService.smtpClient);
        }
 
        [Fact]
        public void CreateMailObject()
        {
            Assert.IsNotNull(emailService.mail);
        }

        [Fact]
        public void Verifying_Mail_Object_Is_Updated()
        {
            //arrange
            var mail = new MailMessage("FROM@yahoo.com", "TO@yahoo.com", "subject", "body");
            MailAddress mailAddress = new MailAddress("TO@yahoo.com");
            EmailService sut_EmailService = new EmailService();
            
            //act
            sut_EmailService.Send("TO@yahoo.com","subject", "body");

            //assert
            Assert.IsTrue(sut_EmailService.mail.To.Contains(mailAddress));
            Assert.IsTrue(sut_EmailService.mail.Subject.Equals(mail.Subject));
            Assert.IsTrue(sut_EmailService.mail.Body.Contains(mail.Body));
        }

    }
}
