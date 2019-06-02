using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobsForYou.Models;
using test.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Collections;
using System.Globalization;

namespace JobsForYou.Controllers
{
    [Authorize(Roles="Hire")]
    public class JobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Job/
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            return View(db.Jobs.ToList().Where(a => a.userid == UserId));
        }

        // GET: /Job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: /Job/Create
        public ActionResult Create()
        {

            ViewBag.CareerLevel =  new SelectList(new[] { "Senior Management Jobs", "Management Jobs", "Experienced Managment Jobs", "Entry Level Jobs", "Internships" });
            ViewBag.JobType = new SelectList(new[]{ "Part Time", "Full Time", "Frelancer", "Work At Home" });
            ViewBag.CatNo = new SelectList(db.Categories, "CatNo", "CatName");
            //ViewBag.UserId = new SelectList(db.Users, "Id", "UserId");
            return View();
        }

        // POST: /Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
             {
                ViewBag.CareerLevel = new SelectList(new[] { "Senior Management Jobs", "Management Jobs", "Experienced Managment Jobs", "Entry Level Jobs", "Internships" });
                ViewBag.JobType = new SelectList(new[] { "Part Time", "Full Time", "Frelancer", "Work At Home" });
                string path = Path.Combine(Server.MapPath("~/JobImages"), file.FileName);
                file.SaveAs(path);
                job.JobImage = file.FileName;
                DateTime T = DateTime.Now;
                job.TimeAdd = T.ToString("MMM dd, yyyy HH:mm");
                var userNo = User.Identity.GetUserId();
                job.userid = userNo;
                  db.Jobs.Add(job);
                  db.SaveChanges();
                return RedirectToAction("Jobs");
            }

            ViewBag.CatNo = new SelectList(db.Categories, "CatNo", "CatName", job.CatNo);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", job.UserId);
            return View(job);
        }

        // GET: /Job/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            ViewBag.CareerLevel = new SelectList(new[] { "Senior Management Jobs", "Management Jobs", "Experienced Managment Jobs", "Entry Level Jobs", "Internships" });
            ViewBag.JobType = new SelectList(new[] { "Part Time", "Full Time", "Frelancer", "Work At Home" });
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatNo = new SelectList(db.Categories, "CatNo", "CatName", job.CatNo);
            return View(job);
        }

        // POST: /Job/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="JobId,JobTitle,Company,JobRequired,CareerLevel,JobType,JobDesc,JobSalary,Vacancies,TimeAdd,AboutJob,Experience,JobImage,CatNo,UserId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatNo = new SelectList(db.Categories, "CatNo", "CatName", job.CatNo);
            return View(job);
        }

        public ActionResult Jobs() 
        {
            return View(db.Jobs.ToList()); 
        }

        // GET: /Job/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
