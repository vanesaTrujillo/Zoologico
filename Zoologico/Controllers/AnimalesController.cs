using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class AnimalesController : Controller
    {
        private db_zoologicoEntities1 db = new db_zoologicoEntities1();

        private SelectList Tipos()
        {
            string[] animales = new string[3] { "Mamífero", "Ave", "Acuático" };
            return new SelectList(animales);
        }

        // GET: Animales
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Animales.ToList());
        }

        // GET: Animales/Detalle/5
        [Authorize]
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(animales);
        }

        // GET: Animales/Crear
        [Authorize]
        public ActionResult Crear()
        {
            ViewBag.Tipo = Tipos();
            return View();
        }

        // POST: Animales/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Id,Nombre,Edad,PaisOrigen,Especie,Subespecie,CostumbresAlimenticias,Tipo")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                db.Animales.Add(animales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = Tipos();
            return View(animales);
        }

        // GET: Animales/Editar/5
        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = Tipos();
            return View(animales);
        }

        // POST: Animales/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Nombre,Edad,PaisOrigen,Especie,Subespecie,CostumbresAlimenticias,Tipo")] Animales animales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = Tipos();
            return View(animales);
        }
        // GET: Animales/Eliminar/5
        [Authorize]
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animales animales = db.Animales.Find(id);
            if (animales == null)
            {
                return HttpNotFound();
            }
            return View(animales);
        }

        // POST: Animales/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            Animales animales = db.Animales.Find(id);
            db.Animales.Remove(animales);
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
