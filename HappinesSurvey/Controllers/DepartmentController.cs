using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.DAL;

namespace HappinesSurvey.Controllers
{
    public class DepartmentController : Controller
    {
        private HapinessSurveyEntities db = new HapinessSurveyEntities();

        // GET: Department
        public ActionResult Index()
        {
            if (Session["RoleID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(db.departmenttbls.ToList());
          
         
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departmenttbl departmenttbl = db.departmenttbls.Find(id);
            if (departmenttbl == null)
            {
                return HttpNotFound();
            }
            return View(departmenttbl);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dep_id,dep_name")] departmenttbl departmenttbl)
        {
            if (ModelState.IsValid)
            {
                db.departmenttbls.Add(departmenttbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmenttbl);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departmenttbl departmenttbl = db.departmenttbls.Find(id);
            if (departmenttbl == null)
            {
                return HttpNotFound();
            }
            return View(departmenttbl);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dep_id,dep_name")] departmenttbl departmenttbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmenttbl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmenttbl);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departmenttbl departmenttbl = db.departmenttbls.Find(id);
            if (departmenttbl == null)
            {
                return HttpNotFound();
            }
            return View(departmenttbl);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            departmenttbl departmenttbl = db.departmenttbls.Find(id);
            db.departmenttbls.Remove(departmenttbl);
            db.SaveChanges();
            return RedirectToAction("Index");
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
