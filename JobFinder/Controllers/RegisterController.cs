using System.Web.Mvc;
using BusinessDomain;
using DAL;

namespace JobFinder.Controllers
{
    public class RegisterController : Controller
    {
        private JobFinderContext db = new JobFinderContext();
        //
        // GET: /Register/Create

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Register/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
