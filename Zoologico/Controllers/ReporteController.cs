using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class ReporteController : Controller
    {
        private db_zoologicoEntities1 db = new db_zoologicoEntities1();

        // GET: Reportes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Reporte.ToList());
        }

        [Authorize]
        public ActionResult Exportar()
        {
            var animales = new DataTable("animales");
            var animalesEnEnfermeria = db.Reporte.ToList();
            animales.Columns.Add("Nombre", typeof(string));
            animales.Columns.Add("Edad", typeof(string));
            animales.Columns.Add("Fecha Ingreso", typeof(string));
            animales.Columns.Add("Diagnóstico", typeof(string));
            foreach (var item in animalesEnEnfermeria)
            {
                animales.Rows.Add(item.Nombre, item.Edad, item.FechaIngreso.ToShortDateString() + " " + item.FechaIngreso.ToShortTimeString(), item.Diagnostico);
            }

            var grid = new GridView();
            grid.DataSource = animales;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "utf-8";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
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
