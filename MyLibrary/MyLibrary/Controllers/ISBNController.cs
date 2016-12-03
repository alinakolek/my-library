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
    public class ISBNController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ISBN/ISBNIndex
        public ActionResult ISBNIndex()
        {
            var iSBN = db.ISBNs.Include(i => i.Edition);
            return View(iSBN.ToList());
        }

        /*
        // GET: ISBN/ISBNDetails/5
        public ActionResult ISBNDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISBN iSBN = db.ISBNs.Find(id);
            if (iSBN == null)
            {
                return HttpNotFound();
            }
            return View(iSBN);
        }
        */

        // GET: ISBN/ISBNCreate
        public ActionResult ISBNCreate()
        {
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace");
            return View();
        }

        // POST: ISBN/ISBNCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ISBNCreate([Bind(Include = "Edition,Id,ISBNNumber")] ISBN iSBN)
        {
            if (ModelState.IsValid)
            {
                db.ISBNs.Add(iSBN);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ISBN record");
                return RedirectToAction("ISBNIndex");
            }

            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace", iSBN.Id);
            DisplayErrorMessage();
            return View(iSBN);
        }

        // GET: ISBN/ISBNEdit/5
        public ActionResult ISBNEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISBN iSBN = db.ISBNs.Find(id);
            if (iSBN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace", iSBN.Id);
            return View(iSBN);
        }

        // POST: ISBNISBN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ISBNEdit([Bind(Include = "Edition,Id,ISBNNumber")] ISBN iSBN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iSBN).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a ISBN record");
                return RedirectToAction("ISBNIndex");
            }
            ViewBag.Id = new SelectList(db.Editions, "Id", "PublicationPlace", iSBN.Id);
            DisplayErrorMessage();
            return View(iSBN);
        }

        // GET: ISBN/ISBNDelete/5
        public ActionResult ISBNDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISBN iSBN = db.ISBNs.Find(id);
            if (iSBN == null)
            {
                return HttpNotFound();
            }
            return View(iSBN);
        }

        // POST: ISBN/ISBNDelete/5
        [HttpPost, ActionName("ISBNDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ISBNDeleteConfirmed(int id)
        {
            ISBN iSBN = db.ISBNs.Find(id);
            db.ISBNs.Remove(iSBN);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a ISBN record");
            return RedirectToAction("ISBNIndex");
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
