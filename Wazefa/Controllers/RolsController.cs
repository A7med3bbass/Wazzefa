using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using System.Data.Entity;

namespace JobsForYou.Models
{
    
    public class RolsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Rols/
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        //
        // GET: /Rols/Details/5
        public ActionResult Details(string id)
        {
            var r = db.Roles.Find(id);
            if (r==null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // GET: /Rols/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rols/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
              return View(Role);
            
        }

        //
        // GET: /Rols/Edit/5
        public ActionResult Edit(string id)
        {
            var r = db.Roles.Find(id);
            if(r==null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // POST: /Rols/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include="Id,Name")] IdentityRole r)
        {
            if (ModelState.IsValid)
            {
                db.Entry(r).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

        //
        // GET: /Rols/Delete/5
        public ActionResult Delete(string id)
        {
            var r = db.Roles.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // POST: /Rols/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole r)
        {
            try
            {
                // TODO: Add delete logic here
                var FoundId = db.Roles.Find(r.Id);
                db.Roles.Remove(FoundId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(r);
            }
        }
    }
}
