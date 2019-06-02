using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using Microsoft.AspNet.Identity;
using JobsForYou.Models;
using System.Data.Entity;
using Wazefa.Models;
using System.Net.Mail;
using System.Net;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Details(int jobId) 
        {
            var job = db.Jobs.Find(jobId);
            if (job==null)
            {
                HttpNotFound();
            }

            Session["jobid"] = jobId;
            return View(job);
        }
        [Authorize]
        public ActionResult ApplyToJob() 
        {
            return View();
        }

        [Authorize]
        public ActionResult DetailsForJobs(int id)
        {
            var job = db.ApplyJobs.Find(id);
            if (job == null)
            {
                HttpNotFound();
            }

            return View(job);
        }

        [HttpPost]
        public ActionResult ApplyToJob(string message)
        {
            var UserId = User.Identity.GetUserId();
            var jobId = (int)Session["jobid"];


            var check = db.ApplyJobs.Where(a => a.JobId == jobId && a.Userid == UserId);

            if (check.Count() < 1)
            {
                var job = new ApplyJobs();

                job.Userid = UserId;
                job.JobId = jobId;
                job.applyTime = DateTime.Now;
                job.message = message;

                db.ApplyJobs.Add(job);
                db.SaveChanges();
                ViewBag.Error = "Message is Send Sucssfully";
            }
            else
            {
                ViewBag.Error = "You Are Applyed To This Job";
            }
         
            return View();
        }

        [Authorize]
        public ActionResult GetJobByUser() 
        {
            var UserId = User.Identity.GetUserId();
            var jobs = db.ApplyJobs.Where(a => a.Userid == UserId);
            return View(jobs.ToList());
        }

        public ActionResult Edit(int id)
        {
            var job = db.ApplyJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //
        // POST: /Rols/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplyJobs job)
        {
            if (ModelState.IsValid)
            {
                job.applyTime = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobByUser");
            }
            return View(job);
        }
        [Authorize]
        public ActionResult GetJobByPublisher() 
        {
            var userID = User.Identity.GetUserId();
            var jobs = from app in db.ApplyJobs
                       join jobing in db.Jobs
                       on app.JobId equals jobing.JobId
                       where jobing.userid == userID
                       select app;

            var Group = from j in jobs
                        group j by j.job.JobTitle
                            into Gr
                            select new JobsViewModel { jobTitle = Gr.Key, items = Gr };
            return View(Group.ToList());

        }

        public ActionResult Delete(int id)
        {
            var r = db.ApplyJobs.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // POST: /Rols/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyJobs job)
        {
            try
            {
                // TODO: Add delete logic here
                var FoundId = db.Roles.Find(job.JobId);
                db.Roles.Remove(FoundId);
                db.SaveChanges();
                return RedirectToAction("GetJobByUser");
            }
            catch
            {
                return View(job);
            }
        }


        public ActionResult Search() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            var Res = db.Jobs.Where(j => j.JobTitle.Contains(SearchName) 
                || j.JobDesc.Contains(SearchName) 
                || j.Cats.CatName.Contains(SearchName)).ToList();
            return View(Res);
        }

        
        public ActionResult About()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ContactUs() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(ContactModel contact)
        {
            var mail = new MailMessage();
            var loginInfo = new NetworkCredential("ahmedrm.ar39@gmail.com", "amrdBass67Kkkks76yuerhhfsfhj438");

            mail.From = new MailAddress(contact.Email);
            mail.To.Add("ahmedrm.ar39@gmail.com");
            mail.Subject = contact.Subject;
            string bodyMessage = "Sender Name: " + contact.Name + "<br/>" +
                                 "Email: " + contact.Email + "<br/>" +
                                 "Subject: " + contact.Subject + "<br/>" +
                                 "Message: <p>" + contact.Message + "</p>";
            mail.Body = bodyMessage;

            SmtpClient sm = new SmtpClient("smtp.gmail.com",587);
            sm.EnableSsl = true;
            sm.Credentials = loginInfo;

            sm.Send(mail);
 

            return View();
        }
    }
}