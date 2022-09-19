using NEGOCIO;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace ORDENESDTRABAJO.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        public ActionResult Index()
        {
            var solicitu = SolicituCN.ListarSolicitud/*ListarSoli*/();
            return View(solicitu);
        }

        public ActionResult Lista()
        {
            var solicitu = SolicituCN.ListarSolicitud();
            return View(solicitu);
        }

        public ActionResult detallesoli(int id)//CAPTURAR ALA INFORMACION
        {
            var solicitu = SolicituCN.detallesoli(id);
            return View(solicitu);

        }

        public JsonResult getsoli()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DE SOLICITUD
        {
            var lista = SolicituCN.ListarSoli();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
         [ValidateAntiForgeryToken]
        public ActionResult Crear(SOLIORDEN solicitud)
        {

            try
            {
                var FECHA = DateTime.Now;
                System.Threading.Thread.Sleep(1000);
                SolicituCN.agregar(solicitud);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(solicitud);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
            }

        }

        [HttpPost]

        public ActionResult elimina(int id)
        {

            try
            {
                SolicituCN.elimina(id);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }

            catch (Exception ex)

            {
                return Json(new { ok = false, msg = "Error al Eliminar un Regristro" }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al Eliminar un Regristro");
                //return View();

            }
        }

        //REPORTES
        public ActionResult Rptsolicitud ()
        {
            return View();
        }

        public ActionResult descargarreporteS(/*int id*/)
        {
            try
            {

                var rptS = new ReportClass();
                rptS.FileName = Server.MapPath("/Reportes/SolicitudReporte.rpt");
                rptS.Load();

                //rptS.SetParameterValue("dptoID",id);

                // Reporte connection
                var connInfo = CrystalReportsCnn.GetConnectionInfo();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = rptS.Database.Tables;
                foreach (Table table in tables)
                {
                    logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                //EN PDF
                Stream stream = rptS.ExportToStream(ExportFormatType.PortableDocFormat);
                rptS.Dispose();
                rptS.Close();
                return new FileStreamResult(stream, "application/pdf");
            }
            catch (Exception ex)
            {
               
                throw;
             

            }

           
        }
    }
}