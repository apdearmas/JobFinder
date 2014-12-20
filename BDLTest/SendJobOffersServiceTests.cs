using BDL;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BDLTest
{
    public class SendJobOffersServiceTests
    {
        private SendJobOffersService sendJobOffersService;
        private Mock<ICustomerService> customerServiceMock;
        private Mock<IJobOffersService> jobOffersServiceMock;

        public SendJobOffersServiceTests()
        {
            customerServiceMock = new Mock<ICustomerService>();
            jobOffersServiceMock = new Mock<IJobOffersService>();
            sendJobOffersService = new SendJobOffersService(customerServiceMock.Object, jobOffersServiceMock.Object);
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

    }
}
