using System.Web.Mvc;
using BDL;

namespace JobFinder.Controllers
{
    public class HomeController : Controller
    {
        private ISendJobOffersService sendJobOffersService;

        public HomeController(ISendJobOffersService sendJobOffersService)
        {
            this.sendJobOffersService = sendJobOffersService;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Contact()
        {
            //sendJobOffersService.SendJobOffers();
            return View();
        }
    }
}
