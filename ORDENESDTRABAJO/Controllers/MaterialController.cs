using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORDENESDTRABAJO.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        {
            var material = MaterialCN.ListarMaterial();
            return View(material);
        }


        public JsonResult getmater()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DE LOS MATERIALES
        {
            var lista = MaterialCN.ListarMaterial();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Crear()//SOLICITA LA VISTA PARA CREAR UN NUENO REGISTRO.
        {

            return View();
        }


        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
        [ValidateAntiForgeryToken]
        public ActionResult Crear(MATERIALES material)
        {

            try
            {
                if (material.METERIAL == null)
                {
                    return Json(new { ok = false, msg = "Debe de ingresar el Material/Herramienta" }, JsonRequestBehavior.AllowGet);
                }


                System.Threading.Thread.Sleep(1000);
                MaterialCN.Agregar(material);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(cargo);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }

        }

        public ActionResult detalleMateri(int id)
        {
            var materiales = MaterialCN.detalleMateri(id);
            return View(materiales);
        }


        [HttpGet]
        public ActionResult editar(int id)//SOLICITA LA VISTA PARA EDITAR UN NUENO REGISTRO.
        {

            var material = MaterialCN.detalleMateri(id);
            return View(material);
        }

        [HttpPost]
        public ActionResult editar(MATERIALES material)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                MaterialCN.editar(material);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Editar un Regristro");
                //return View(material);
                return Json(new { ok = false, msg = "Error al Editar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }
        }


        [HttpPost]
        public ActionResult elimina(int id)
        {

            try
            {

                MaterialCN.elimina(id);
                //return RedirectToAction("Index");
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Eliminar un Regristro");
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);
                //return View();

            }

        }
    }
}