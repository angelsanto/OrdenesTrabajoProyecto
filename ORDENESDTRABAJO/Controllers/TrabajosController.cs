using NEGOCIO;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORDENESDTRABAJO.Controllers
{
    public class TrabajosController : Controller
    {
        // GET: Trabajos
        public ActionResult Index()
        {
            var trabajo = TrabajoCN.ListarTrabajo();
            return View(trabajo);
        }


        public JsonResult gettrabajo(int ID_CATEGO)//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DEL TRABAJO
        {
            var lista = TrabajoCN.ListarTraba(ID_CATEGO);
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
        [ValidateAntiForgeryToken]
        public ActionResult Crear(TRABAJOSREALIZADOS trabajo)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                TrabajoCN.agregar(trabajo);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(trabajo);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
            }

        }


        public ActionResult detalletrabajo(int id)//CAPTURAR ALA INFORMACION
        {
            var trabajo = TrabajoCN.detalletrabajo(id);
            return View(trabajo);

        }


        [HttpGet]
        public ActionResult editar(int id)//CAPTURAR ALA INFORMACION
        {
            var trabajos = TrabajoCN.detalletrabajo(id);
            return View(trabajos);

        }

        [HttpPost]
        public ActionResult editar(TRABAJOSREALIZADOS trabajo)
        {
            try
            {
                TrabajoCN.editar(trabajo);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { ok = false, msg = "Error al Editar un Regristro" }, JsonRequestBehavior.AllowGet);
                //return View();
            }

        }

        [HttpPost]

        public ActionResult elimina(int id)
        {

            try
            {
                TrabajoCN.elimina(id);
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