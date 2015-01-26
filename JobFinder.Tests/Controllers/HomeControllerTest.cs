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
        private readonly Mock<ISendJobOffersService> sendJobOffersServiceMock;

        public HomeControllerTest()
        {
            sendJobOffersServiceMock = new Mock<ISendJobOffersService>();
        }

        [Fact]
        public void Index()
        {
            var controller = new HomeController(sendJobOffersServiceMock.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Fact]
        public void Contact()
        {
            sendJobOffersServiceMock.Setup(m => m.SendJobOffers()).Verifiable();
            var controller = new HomeController(sendJobOffersServiceMock.Object);

            var result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
            sendJobOffersServiceMock.Verify(m => m.SendJobOffers());
        }
    }
}
