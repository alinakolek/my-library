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
    public class CoverTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CoverType/CoverTypeIndex
        public ActionResult CoverTypeIndex()
        {
            var coverType = db.CoverTypies.Include(c => c.BookStatus);
            return View(coverType.ToList());
        }

        /*
        // GET: CoverType/CoverTypeDetails/5
        public ActionResult CoverTypeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoverType coverType = db.CoverTypies.Find(id);
            if (coverType == null)
            {
                return HttpNotFound();
            }
            return View(coverType);
        }
        */

        // GET: CoverType/CoverTypeCreate
        public ActionResult CoverTypeCreate()
        {
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName");
            return View();
        }

        // POST: CoverType/CoverTypeCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CoverTypeCreate([Bind(Include = "BookStatus,Id,IsHardback")] CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                db.CoverTypies.Add(coverType);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a CoverType record");
                return RedirectToAction("CoverTypeIndex");
            }

            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", coverType.Id);
            DisplayErrorMessage();
            return View(coverType);
        }

        // GET: CoverType/CoverTypeEdit/5
        public ActionResult CoverTypeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoverType coverType = db.CoverTypies.Find(id);
            if (coverType == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", coverType.Id);
            return View(coverType);
        }

        // POST: CoverTypeCoverType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CoverTypeEdit([Bind(Include = "BookStatus,Id,IsHardback")] CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coverType).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a CoverType record");
                return RedirectToAction("CoverTypeIndex");
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", coverType.Id);
            DisplayErrorMessage();
            return View(coverType);
        }

        // GET: CoverType/CoverTypeDelete/5
        public ActionResult CoverTypeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoverType coverType = db.CoverTypies.Find(id);
            if (coverType == null)
            {
                return HttpNotFound();
            }
            return View(coverType);
        }

        // POST: CoverType/CoverTypeDelete/5
        [HttpPost, ActionName("CoverTypeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CoverTypeDeleteConfirmed(int id)
        {
            CoverType coverType = db.CoverTypies.Find(id);
            db.CoverTypies.Remove(coverType);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a CoverType record");
            return RedirectToAction("CoverTypeIndex");
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
