using System.Web.Mvc;
using BDL;
using DAL;
using System.Linq;

namespace JobFinder.Controllers
{
    public class HomeController : Controller
    {
        private ISendJobOffersService sendJobOffersService;
        JobFinderContext _db = new JobFinderContext();

        public HomeController(ISendJobOffersService sendJobOffersService)
        {
            this.sendJobOffersService = sendJobOffersService;
        }


        public ActionResult Index(string searchTerm = null)
        {

            //var model = from r in _db.JobOffers
            //            where( searchTerm == null || r.Title.StartsWith(searchTerm))    
            //            orderby r.IssuedDate
            //            select r;

            var model = _db.JobOffers
                .OrderBy(r => r.IssuedDate)
                .Where(r => searchTerm == null || r.Title.StartsWith(searchTerm))
                .Take(10);
                //.Select r;


            return View(model);
        }


        public ActionResult Contact()
        {
            //sendJobOffersService.SendJobOffers();
            return View();
        }
    }
}
