using ENTIDAD;
using NEGOCIO;
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
 
    public class VistaDetalleController : Controller
    {
        // GET: VistaDetalle

        [Authorize(Roles ="Admin")]
        public ActionResult detalle()
        {

            var orden = VistaDCN.listadetalle();
            return View(orden);

        }

        public ActionResult DetalleVista()
        {

            var orden = OrdenCN.listarOrden();
            return View(orden);

        }


        public ActionResult parcialvista (int id)
        {
            var vistaP = VistaDCN.lista(id);
            return PartialView(vistaP);

        }



        [HttpPost]

        public ActionResult elimina(int id)
        {

            try
            {
                VistaDCN.elimina(id);
                return Json(new { ok = true, toRedirect = Url.Action("agregartrabajos") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }

            catch (Exception ex)

            {

                //ModelState.AddModelError("", "Error al Eliminar un Regristro");
                return Json(new { ok = false, msg = "Error al Eliminar un Regristro" }, JsonRequestBehavior.AllowGet);
                //return View();


            }

        }

        //VISTA PARA AGREGAR TRABAJOS
        public ActionResult agregartrabajos()
        {
            return View(/*VistaDCN.listadetalletemp()*/);
           
        }


        //PARA GUARDAR EN MAESTRO DETALLE
        [HttpPost]
        public ActionResult CrearDetalle(DETALLEORDEN[] detalle)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);
                VistaDCN.guardarDT(detalle);
                return Json(new { ok = true, toRedirect = Url.Action("DetalleVista") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(trabajo);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
            }

        }


        //REPORTES
        public ActionResult Rptorden()
        {
            return View();
        }

        public ActionResult descargarreporteO()
        {
            try
            {

                var rptO = new ReportClass();
                rptO.FileName = Server.MapPath("/Reportes/OrdenReporte.rpt");
                rptO.Load();

                

                // Reporte connection
                var connInfo = CrystalReportsCnn.GetConnectionInfo();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = rptO.Database.Tables;
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
                Stream stream = rptO.ExportToStream(ExportFormatType.PortableDocFormat);
                rptO.Dispose();
                rptO.Close();
                return new FileStreamResult(stream, "application/pdf");
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}