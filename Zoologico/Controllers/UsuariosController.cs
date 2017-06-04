using Newtonsoft.Json;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class UsuariosController : Controller
    {
        private db_zoologicoEntities1 db = new db_zoologicoEntities1();

        // GET: Usuarios
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Crear
        [Authorize]
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Usuarios/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "Nombre,Contrasena,Id")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: Usuarios/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Nombre,Contrasena,Id")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Eliminar/5
        [Authorize]
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Nombre,Contrasena")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.Nombre == usuarios.Nombre && u.Contrasena == usuarios.Contrasena);
                if (usuario == null)
                {
                    ViewBag.Mensaje = "Usuario o contraseña incorrectos.";
                    return View(usuario);
                }
                FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(usuario), false);
                return RedirectToAction("Index", "Home");
            }
            return View(usuarios);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
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
