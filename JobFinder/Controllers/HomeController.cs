using System.Web.Mvc;
using BDL;

namespace JobFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISendJobOffersService sendJobOffersService;

        public HomeController(ISendJobOffersService sendJobOffersService)
        {
            this.sendJobOffersService = sendJobOffersService;

        }

        public ActionResult Index()
        {
            sendJobOffersService.SendJobOffers();

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
