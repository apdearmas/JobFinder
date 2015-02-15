using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BusinessDomain;
using DAL;
using System.Data;

namespace JobFinder.Controllers
{
    [Authorize(Roles="Admin")]
    public class JobOffersController : Controller
    {
        private JobFinderContext db = new JobFinderContext();

        //
        // GET: /JobOffers/

        public ActionResult Index()
        {
            return View(db.JobOffers.ToList());
        }

        //
        // GET: /JobOffers/Details/5

        public ActionResult Details(int id = 0)
        {
            JobOffer joboffer = db.JobOffers.Find(id);
            if (joboffer == null)
            {
                return HttpNotFound();
            }
            return View(joboffer);
        }

        //
        // GET: /JobOffers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /JobOffers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOffer joboffer)
        {
            if (ModelState.IsValid)
            {
                db.JobOffers.Add(joboffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(joboffer);
        }

        //
        // GET: /JobOffers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            JobOffer joboffer = db.JobOffers.Find(id);
            if (joboffer == null)
            {
                return HttpNotFound();
            }
            return View(joboffer);
        }

        //
        // POST: /JobOffers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobOffer joboffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joboffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(joboffer);
        }

        //
        // GET: /JobOffers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            JobOffer joboffer = db.JobOffers.Find(id);
            if (joboffer == null)
            {
                return HttpNotFound();
            }
            return View(joboffer);
        }

        //
        // POST: /JobOffers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobOffer joboffer = db.JobOffers.Find(id);
            db.JobOffers.Remove(joboffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}