using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessDomain;
using DAL;

namespace JobFinder.Controllers
{
    public class PostJobController : Controller
    {
        private JobFinderContext db = new JobFinderContext();
        //
        // GET: /PostJob/Create

        public ActionResult PostJob()
        {
            return View();
        }

        //
        // POST: /PostJob/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostJob(JobOffer joboffer)
        {
            if (ModelState.IsValid)
            {
                db.JobOffers.Add(joboffer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(joboffer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
