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
    public class FileExtensionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FileExtension/FileExtensionIndex
        public ActionResult FileExtensionIndex()
        {
            var fileExtension = db.FileExtensions.Include(f => f.BookStatus);
            return View(fileExtension.ToList());
        }

        /*
        // GET: FileExtension/FileExtensionDetails/5
        public ActionResult FileExtensionDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileExtension fileExtension = db.FileExtensions.Find(id);
            if (fileExtension == null)
            {
                return HttpNotFound();
            }
            return View(fileExtension);
        }
        */

        // GET: FileExtension/FileExtensionCreate
        public ActionResult FileExtensionCreate()
        {
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName");
            return View();
        }

        // POST: FileExtension/FileExtensionCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileExtensionCreate([Bind(Include = "BookStatus,Id,Type")] FileExtension fileExtension)
        {
            if (ModelState.IsValid)
            {
                db.FileExtensions.Add(fileExtension);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a FileExtension record");
                return RedirectToAction("FileExtensionIndex");
            }

            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", fileExtension.Id);
            DisplayErrorMessage();
            return View(fileExtension);
        }

        // GET: FileExtension/FileExtensionEdit/5
        public ActionResult FileExtensionEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileExtension fileExtension = db.FileExtensions.Find(id);
            if (fileExtension == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", fileExtension.Id);
            return View(fileExtension);
        }

        // POST: FileExtensionFileExtension/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileExtensionEdit([Bind(Include = "BookStatus,Id,Type")] FileExtension fileExtension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileExtension).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a FileExtension record");
                return RedirectToAction("FileExtensionIndex");
            }
            ViewBag.Id = new SelectList(db.BookStatuses, "Id", "UserName", fileExtension.Id);
            DisplayErrorMessage();
            return View(fileExtension);
        }

        // GET: FileExtension/FileExtensionDelete/5
        public ActionResult FileExtensionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileExtension fileExtension = db.FileExtensions.Find(id);
            if (fileExtension == null)
            {
                return HttpNotFound();
            }
            return View(fileExtension);
        }

        // POST: FileExtension/FileExtensionDelete/5
        [HttpPost, ActionName("FileExtensionDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FileExtensionDeleteConfirmed(int id)
        {
            FileExtension fileExtension = db.FileExtensions.Find(id);
            db.FileExtensions.Remove(fileExtension);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a FileExtension record");
            return RedirectToAction("FileExtensionIndex");
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
