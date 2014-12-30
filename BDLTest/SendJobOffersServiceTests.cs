using BDL;
using BusinessDomain;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BDLTest
{
    public class SendJobOffersServiceTests
    {
        private SendJobOffersService sendJobOffersService;
        private Mock<ICustomerService> customerServiceMock;
        private Mock<IJobOffersService> jobOffersServiceMock;

        private Mock<IEmailService> emailServiceMock;

        public SendJobOffersServiceTests()
        {
            customerServiceMock = new Mock<ICustomerService>();
            jobOffersServiceMock = new Mock<IJobOffersService>();
            emailServiceMock = new Mock<IEmailService>();

            sendJobOffersService = new SendJobOffersService(customerServiceMock.Object, jobOffersServiceMock.Object, emailServiceMock.Object);
        }

        [Fact]
        public void Create()
        {
            Assert.IsNotNull(sendJobOffersService);
        }

        [Fact]
        public void CustomerServiceFindAllIsCalled()
        {
            customerServiceMock.Setup(m => m.FindAll()).Verifiable();
            sendJobOffersService.SendJobOffers();
            customerServiceMock.Verify(m => m.FindAll(), Times.Once);
        }

        [Fact]
        public void JobOffersServiceFindAllIsCalled()
        {
            jobOffersServiceMock.Setup(m => m.FindAll()).Verifiable();
            sendJobOffersService.SendJobOffers();
            jobOffersServiceMock.Verify(m => m.FindAll(), Times.Once);
        }

        [Fact]
        public void SendJobOffersToEachCustomer()
        {
            var customer1 = new Customer();
            var customer2 = new Customer();
            var customer3 = new Customer();
            var customerList = new List<Customer> { customer1, customer2, customer3}.AsQueryable();
            customerServiceMock.Setup(m => m.FindAll()).Returns(customerList);
            emailServiceMock.Setup(
                m => m.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
 
            sendJobOffersService.SendJobOffers();

            emailServiceMock.Verify(
                m => m.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), 
                Times.Exactly(3));
        }

        [Fact]
        public void VerifyCustomerEmailIsPassedToEmailServiceSend()
        {
            var customer = new Customer { EMail="xxx@x.com" };
            var customerList = new List<Customer> { customer }.AsQueryable();
            customerServiceMock.Setup(m => m.FindAll()).Returns(customerList);

            string email = string.Empty;
            emailServiceMock.Setup(
                m => m.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string, string>( (s1, s2, s3) => email = s1 );

            sendJobOffersService.SendJobOffers();

            Assert.IsTrue(email.Equals(customer.EMail));

        }


       

    }
}
