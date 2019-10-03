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
    public class quesController : Controller
    {
        private HapinessSurveyEntities db = new HapinessSurveyEntities();

        // GET: ques
        public ActionResult Index()
        {
            return View(db.questiontbls.ToList());
        }

        // GET: ques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            questiontbl questiontbl = db.questiontbls.Find(id);
            if (questiontbl == null)
            {
                return HttpNotFound();
            }
            return View(questiontbl);
        }

        // GET: ques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "q_id,question")] questiontbl questiontbl)
        {
            if (ModelState.IsValid)
            {
                db.questiontbls.Add(questiontbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questiontbl);
        }

        // GET: ques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            questiontbl questiontbl = db.questiontbls.Find(id);
            if (questiontbl == null)
            {
                return HttpNotFound();
            }
            return View(questiontbl);
        }

        // POST: ques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "q_id,question")] questiontbl questiontbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questiontbl).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questiontbl);
        }

        // GET: ques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            questiontbl questiontbl = db.questiontbls.Find(id);
            if (questiontbl == null)
            {
                return HttpNotFound();
            }
            return View(questiontbl);
        }

        // POST: ques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            questiontbl questiontbl = db.questiontbls.Find(id);
            db.questiontbls.Remove(questiontbl);
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
