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
    public class ComentarioController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Comentario/

        public ActionResult Index()
        {
            return View(db.Comentarios.ToList());
        }

        //
        // GET: /Comentario/Details/5

        public ActionResult Details(int id = 0)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        //
        // GET: /Comentario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comentario/Create

        [HttpPost]
        public ActionResult Create(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comentario);
        }

        //
        // GET: /Comentario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        //
        // POST: /Comentario/Edit/5

        [HttpPost]
        public ActionResult Edit(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        //
        // GET: /Comentario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        //
        // POST: /Comentario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentario);
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