using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.DBContext;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class PublishingHouseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PublishingHouse/PublishingHouseIndex
        public ActionResult PublishingHouseIndex()
        {
            return View(db.PublishingHouses.ToList());
        }

        /*
        // GET: PublishingHouse/PublishingHouseDetails/5
        public ActionResult PublishingHouseDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublishingHouse publishingHouse = db.PublishingHouses.Find(id);
            if (publishingHouse == null)
            {
                return HttpNotFound();
            }
            return View(publishingHouse);
        }
        */

        // GET: PublishingHouse/PublishingHouseCreate
        public ActionResult PublishingHouseCreate()
        {
            return View();
        }

        // POST: PublishingHouse/PublishingHouseCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishingHouseCreate([Bind(Include = "Editions,Id,Name")] PublishingHouse publishingHouse)
        {
            if (ModelState.IsValid)
            {
                db.PublishingHouses.Add(publishingHouse);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a PublishingHouse record");
                return RedirectToAction("PublishingHouseIndex");
            }

            DisplayErrorMessage();
            return View(publishingHouse);
        }

        // GET: PublishingHouse/PublishingHouseEdit/5
        public ActionResult PublishingHouseEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublishingHouse publishingHouse = db.PublishingHouses.Find(id);
            if (publishingHouse == null)
            {
                return HttpNotFound();
            }
            return View(publishingHouse);
        }

        // POST: PublishingHousePublishingHouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishingHouseEdit([Bind(Include = "Editions,Id,Name")] PublishingHouse publishingHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publishingHouse).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a PublishingHouse record");
                return RedirectToAction("PublishingHouseIndex");
            }
            DisplayErrorMessage();
            return View(publishingHouse);
        }

        // GET: PublishingHouse/PublishingHouseDelete/5
        public ActionResult PublishingHouseDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublishingHouse publishingHouse = db.PublishingHouses.Find(id);
            if (publishingHouse == null)
            {
                return HttpNotFound();
            }
            return View(publishingHouse);
        }

        // POST: PublishingHouse/PublishingHouseDelete/5
        [HttpPost, ActionName("PublishingHouseDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishingHouseDeleteConfirmed(int id)
        {
            PublishingHouse publishingHouse = db.PublishingHouses.Find(id);
            db.PublishingHouses.Remove(publishingHouse);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a PublishingHouse record");
            return RedirectToAction("PublishingHouseIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
