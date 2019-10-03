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
    public class AddUserController : Controller
    {
        private HapinessSurveyEntities db = new HapinessSurveyEntities();

        // GET: AddUser
        public ActionResult Index()
        {
            var userTbls = db.UserTbls.Include(u => u.departmenttbl);
            return View(userTbls.ToList());
        }

        // GET: AddUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = db.UserTbls.Find(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // GET: AddUser/Create
        public ActionResult Create()
        {
            ViewBag.Dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name");
            return View();
        }

        // POST: AddUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_mail,user_Pass,Dep_id")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.UserTbls.Add(userTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name", userTbl.Dep_id);
            return View(userTbl);
        }

        // GET: AddUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = db.UserTbls.Find(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name", userTbl.Dep_id);
            return View(userTbl);
        }

        // POST: AddUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_mail,user_Pass,Dep_id")] UserTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTbl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name", userTbl.Dep_id);
            return View(userTbl);
        }

        // GET: AddUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTbl userTbl = db.UserTbls.Find(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // POST: AddUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTbl userTbl = db.UserTbls.Find(id);
            db.UserTbls.Remove(userTbl);
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
