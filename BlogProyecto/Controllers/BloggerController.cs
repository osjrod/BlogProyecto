using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProyecto.Models;

namespace BlogProyecto.Controllers
{
    public class BloggerController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Blogger/

        public ActionResult Index()
        {
            return View(db.Bloggers.ToList());
        }

        //
        // GET: /Blogger/Details/5

        public ActionResult Details(int id = 0)
        {
            Blogger blogger = db.Bloggers.Find(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        //
        // GET: /Blogger/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blogger/Create

        [HttpPost]
        public ActionResult Create(Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                db.Bloggers.Add(blogger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogger);
        }

        //
        // GET: /Blogger/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Blogger blogger = db.Bloggers.Find(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        //
        // POST: /Blogger/Edit/5

        [HttpPost]
        public ActionResult Edit(Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogger);
        }

        //
        // GET: /Blogger/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Blogger blogger = db.Bloggers.Find(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        //
        // POST: /Blogger/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Blogger blogger = db.Bloggers.Find(id);
            db.Bloggers.Remove(blogger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}