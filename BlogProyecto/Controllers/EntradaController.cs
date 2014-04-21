using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProyecto.Models;
using PagedList.Mvc;
using PagedList;
using BlogProyecto.Filters;


namespace BlogProyecto.Controllers
{

    public class EntradaController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Entrada/

        public ViewResult Index(int page = 1)
        {

            Blog blog = db.Blogs.Find(1);
            ViewBag.blog = blog;

            Blogger blogger = db.Bloggers.Find(1);
            ViewBag.blogger = blogger; 

            List<Entrada> model = this.db.Entradas.ToList();
            model.Reverse();

            const int pageSize = 3;
            return View(model.ToPagedList(page, pageSize));
        }

        //
        // GET: /Entrada/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        //
        // GET: /Entrada/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Entrada/Create

         [ValidateInput(false)]
        [HttpPost]
        [Authorize]
        public ActionResult Create(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entradas.Add(entrada);
                db.SaveChanges();
                return Redirect("/Admin");
            }

            return View(entrada);
        }

        //
        // GET: /Entrada/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        //
        // POST: /Entrada/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Admin");
            }
            return View(entrada);
        }

       

        [Authorize]
        public ActionResult List()
        {
           

            return View(db.Entradas.ToList());
        }

        //
        // POST: /Entrada/Delete/5

        [ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrada entrada = db.Entradas.Find(id);
            db.Entradas.Remove(entrada);
            db.SaveChanges();
            return Redirect("/Admin");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}