using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProyecto.Models;
using System.Data.Entity;
using System.Data;

namespace BlogProyecto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private Context db = new Context();
        //
        // GET: /Admin/

        public ActionResult Entradas()
        {
            Blog blog = db.Blogs.Find(1);
            ViewBag.blog = blog;

            Blogger blogger = db.Bloggers.Find(1);
            ViewBag.blogger = blogger; 

            return View(db.Entradas.ToList());
        }

        public ActionResult CreateEntrada()
        {
            return Redirect("/Entrada/Create");
        }

        public ActionResult EntradaDetails(int id = 0)
        {

            return Redirect("/Entrada/Details/"+id);
        }
        public ActionResult EntradaEdit(int id = 0)
        {

            return Redirect("/Entrada/Edit/" + id);
        }
        public ActionResult EntradaDelete(int id = 0)
        {

            return Redirect("/Entrada/Delete/" + id);
        }
    }
}
