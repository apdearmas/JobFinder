using System.Web.Mvc;
using BDL;
using JobFinder.Controllers;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JobFinder.Tests.Controllers
{

    public class HomeControllerTest
    {
        private readonly Mock<ISendJobOffersService> sendJobOffesrServiceMock;

        public HomeControllerTest()
        {
            sendJobOffesrServiceMock = new Mock<ISendJobOffersService>();
        }
        [Fact]
        public void Index()
        {
            sendJobOffesrServiceMock.Setup(m => m.SendJobOffers()).Verifiable();

            var controller = new HomeController(sendJobOffesrServiceMock.Object);

            var result = controller.Index() as ViewResult;

            sendJobOffesrServiceMock.Verify(m => m.SendJobOffers(), Times.Once);

            Assert.IsNotNull(result);
        }

        [Fact]
        public void Contact()
        {
            var controller = new HomeController(sendJobOffesrServiceMock.Object);

            var result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
