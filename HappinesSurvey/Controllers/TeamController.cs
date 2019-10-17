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
    public class teamController : Controller
    {
        private HapinessSurveyEntities db = new HapinessSurveyEntities();

        // GET: team
        public ActionResult Index()
        {
            if (Session["RoleID"] == null)

            {
                return RedirectToAction("Login", "Home");

            }
            var teamtbls = db.teamtbls.Include(t => t.projecttbl).Include(t => t.roletbl).Include(t => t.departmenttbl).Include(t => t.UserTbl);
            return View(teamtbls.ToList());
        }

        // GET: team/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teamtbl teamtbl = db.teamtbls.Find(id);
            if (teamtbl == null)
            {
                return HttpNotFound();
            }
            return View(teamtbl);
        }

        // GET: team/Create
        public ActionResult Create()
        {
            ViewBag.pro_id = new SelectList(db.projecttbls, "pro_id", "pro_name");
            ViewBag.role_id = new SelectList(db.roletbls, "role_id", "role_name");
            ViewBag.dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name");
            ViewBag.user_id = new SelectList(getusers(ViewBag.dep_id), "user_id", "user_name");
            return View();
        }

        // POST: team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "team_id,dep_id,pro_id,user_id,role_id")] teamtbl teamtbl)
        {
            if (ModelState.IsValid)
            {
                db.teamtbls.Add(teamtbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pro_id = new SelectList(db.projecttbls, "pro_id", "pro_name", teamtbl.pro_id);
            ViewBag.role_id = new SelectList(db.roletbls, "role_id", "role_name", teamtbl.role_id);
            ViewBag.user_id = new SelectList(db.UserTbls, "user_id", "user_name", teamtbl.user_id);
            ViewBag.dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name", teamtbl.dep_id);
            return View(teamtbl);
        }

        // GET: team/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teamtbl teamtbl = db.teamtbls.Find(id);
            if (teamtbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.pro_id = new SelectList(db.projecttbls, "pro_id", "pro_name", teamtbl.pro_id);
            ViewBag.role_id = new SelectList(db.roletbls, "role_id", "role_name", teamtbl.role_id);
            ViewBag.user_id = new SelectList(db.UserTbls, "user_id", "user_name", teamtbl.user_id);
            ViewBag.dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name", teamtbl.dep_id);
            return View(teamtbl);
        }

        // POST: team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "team_id,dep_id,pro_id,user_id,role_id")] teamtbl teamtbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamtbl).State =System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pro_id = new SelectList(db.projecttbls, "pro_id", "pro_name", teamtbl.pro_id);
            ViewBag.role_id = new SelectList(db.roletbls, "role_id", "role_name", teamtbl.role_id);
            ViewBag.user_id = new SelectList(db.UserTbls, "user_id", "user_name", teamtbl.user_id);
            ViewBag.dep_id = new SelectList(db.departmenttbls, "dep_id", "dep_name", teamtbl.dep_id);
            return View(teamtbl);
        }

        // GET: team/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teamtbl teamtbl = db.teamtbls.Find(id);
            if (teamtbl == null)
            {
                return HttpNotFound();
            }
            return View(teamtbl);
        }

        // POST: team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teamtbl teamtbl = db.teamtbls.Find(id);
            db.teamtbls.Remove(teamtbl);
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

        public static List<SelectListItem> getusers(int dep_id)
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                List<SelectListItem> userlist = (from u in entities.UserTbls
                                                 join d in entities.departmenttbls.AsEnumerable() on u.Dep_id equals d.dep_id
                                                 select new SelectListItem { Text = u.user_name, Value = u.user_id.ToString() }).ToList();

                userlist.Insert(0, new SelectListItem { Text = "--Select User--", Value = "0" });
                    return userlist;
            }

            
        }

    }
}
