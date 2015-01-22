using System.Web.Mvc;
using JobFinder.Controllers;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace JobFinder.Tests.Controllers
{

    public class HomeControllerTest
    {

        [Fact]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Fact]
        public void Contact()
        {
            var controller = new HomeController();

            var result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
