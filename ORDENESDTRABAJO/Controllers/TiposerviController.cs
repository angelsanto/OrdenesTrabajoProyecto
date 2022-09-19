using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORDENESDTRABAJO.Controllers
{
    public class TiposerviController : Controller
    {
        // GET: Tiposervi
        public ActionResult Index()
        {
            var tiposervi = TiposerviCN.listarTiposervi();
            return View(tiposervi);
        }

        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(TIPOSERVICIO tiposervicio)
        {

            try
            {
                if (tiposervicio.CATEGORIA == null)
                {
                    return Json(new { ok = false, msg = "Debe de ingresar el Tipo de Servicio" }, JsonRequestBehavior.AllowGet);
                }

                System.Threading.Thread.Sleep(1000);
                TiposerviCN.agregar(tiposervicio);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(tiposervicio);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }

        }

        public JsonResult getcategoria()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DEL CARGO
        {
            var lista = TiposerviCN.listarTiposervi();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult detalleservicio(int id)
        {
            var tiposervic = TiposerviCN.detalleservicio(id);
            return View(tiposervic);
        }

        [HttpGet]
        public ActionResult editar(int id)
        {
            var tiposervicio = TiposerviCN.detalleservicio(id);
            return View(tiposervicio);

        }

        [HttpPost]
        public ActionResult editar(TIPOSERVICIO tiposervicio)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                TiposerviCN.editar(tiposervicio);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al editar un registro");
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return View(departamento);
            }

        }

        [HttpPost]

        public ActionResult elimina(int id)
        {

            try
            {
                TiposerviCN.elimina(id);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }

            catch (Exception ex)

            {

                //ModelState.AddModelError("", "Error al Eliminar un Regristro");
                return Json(new { ok = false, msg = "Error al Eliminar un Regristro" }, JsonRequestBehavior.AllowGet);
                //return View();


            }

        }

    }
}