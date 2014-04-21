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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Comentarios.ToList());
        }

        //
        // GET: /Comentario/Details/5
        [Authorize(Roles = "Admin")]
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

        [Authorize]
        public ActionResult Create()
        {
            return Redirect("/");
        }

        //
        // POST: /Comentario/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return Redirect("/Entrada/index");
            }

            return Redirect("/Entrada/index");
        }

        //
        // GET: /Comentario/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ActiveDeactive(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);

            if (comentario.Activo)
            {
                comentario.Activo = false;
            }
            else
            {
                comentario.Activo = true;
            }

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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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