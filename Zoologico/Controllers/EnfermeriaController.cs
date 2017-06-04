using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class EnfermeriaController : Controller
    {
        private db_zoologicoEntities1 db = new db_zoologicoEntities1();

        // GET: Enfermeria
        [Authorize]
        public ActionResult Index()
        {
            var enfermeria = db.Enfermeria.Include(e => e.Animales);
            return View(enfermeria.ToList());
        }

        // GET: Enfermeria/Crear
        [Authorize]
        public ActionResult Crear()
        {
            ViewBag.IdAnimal = new SelectList(db.Animales, "Id", "Nombre");
            return View();
        }

        // POST: Enfermeria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id,IdAnimal,FechaIngreso,Diagnostico")] Enfermeria enfermeria)
        {
            if (ModelState.IsValid)
            {
                enfermeria.FechaIngreso = DateTime.Now;
                db.Enfermeria.Add(enfermeria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimal = new SelectList(db.Animales, "Id", "Nombre", enfermeria.IdAnimal);
            return View(enfermeria);
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
