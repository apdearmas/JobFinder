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

            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }
    }
}
