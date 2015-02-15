using System.Web.Mvc;
using BDL;
using DAL;
using System.Linq;
using BusinessDomain;

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

 
            var model = from r in _db.JobOffers
                        where (searchTerm == null || r.Title.StartsWith(searchTerm))
                        orderby r.IssuedDate
                        select new JobOfferListViewModel
                        {
                            Id = r.Id,
                            Title = r.Title,
                            IssuedDate = r.IssuedDate,
                            ExpirationDate= r.ExpirationDate,
                            Description= r.Description,
                            ContactPerson= r.ContactPerson,
                            Location = r.Location
                            
                        };

            //var model = _db.JobOffers
            //    .OrderBy(r => r.IssuedDate)
            //    .Where(r => searchTerm == null || r.Title.StartsWith(searchTerm))
            //    .Take(10);
            //    //.Select (new JobOfferListViewModel
                        //{
                        //    Id = r.Id,
                        //    Title = r.Title,
                        //    IssuedDate = r.IssuedDate,
                        //    ExpirationDate= r.ExpirationDate,
                        //    Description= r.Description,
                        //    ContactPerson= r.ContactPerson,
                        //    City = (from l in _db.Locations where l.Id == r.LocationId select l.City)
                            
                        //});


            return View(model);
        }

        public ActionResult JobsSelected(string searchTerm = null)
        {
           // var model = new JobOfferListViewModel();
            var model = from r in _db.JobOffers
                        where (searchTerm == null || r.Title.StartsWith(searchTerm))
                        orderby r.IssuedDate
                        select new JobOfferListViewModel
                        {
                            Id = r.Id,
                            Title = r.Title,
                            IssuedDate = r.IssuedDate,
                            ExpirationDate = r.ExpirationDate,
                            Description = r.Description,
                            ContactPerson = r.ContactPerson,

                            //City = from loc in _db.Locations where (loc.Id == r.LocationId) select loc.City
                            // City = _db.Locations.Find(r.LocationId).City

                        };
            
            return View(model);
        }


        public ActionResult Contact()
        {
            //sendJobOffersService.SendJobOffers();
            return View();
        }
    }
}
