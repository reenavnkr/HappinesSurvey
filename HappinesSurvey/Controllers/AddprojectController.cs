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
    public class AddprojectController : Controller
    {
        private HapinessSurveyEntities db = new HapinessSurveyEntities();

        // GET: Addproject
        public ActionResult Index()
        {
            if (Session["RoleID"] == null)
            {
                return RedirectToAction("Login", "Home");
             
            }
            return View(db.projecttbls.ToList());
        }

        // GET: Addproject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projecttbl projecttbl = db.projecttbls.Find(id);
            if (projecttbl == null)
            {
                return HttpNotFound();
            }
            return View(projecttbl);
        }

        // GET: Addproject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addproject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pro_id,pro_name,pro_status")] projecttbl projecttbl)
        {
            if (ModelState.IsValid)
            {
                db.projecttbls.Add(projecttbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projecttbl);
        }

        // GET: Addproject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projecttbl projecttbl = db.projecttbls.Find(id);
            if (projecttbl == null)
            {
                return HttpNotFound();
            }
            return View(projecttbl);
        }

        // POST: Addproject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pro_id,pro_name,pro_status")] projecttbl projecttbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecttbl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projecttbl);
        }

        // GET: Addproject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projecttbl projecttbl = db.projecttbls.Find(id);
            if (projecttbl == null)
            {
                return HttpNotFound();
            }
            return View(projecttbl);
        }

        // POST: Addproject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            projecttbl projecttbl = db.projecttbls.Find(id);
            db.projecttbls.Remove(projecttbl);
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
