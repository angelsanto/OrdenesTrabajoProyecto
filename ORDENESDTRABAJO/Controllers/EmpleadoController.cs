using NEGOCIO;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ORDENESDTRABAJO.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = empleCN.listaremple();
            return View(empleado);
        }



        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
        [ValidateAntiForgeryToken]
        public ActionResult Crear(EMPLEADO empleado)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                empleCN.agregar(empleado);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(empleado);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }

        }

        public ActionResult detallemple(int id)//CAPTURAR ALA INFORMACION
        {
            var empleado = empleCN.detallemple(id);
            return View(empleado);

        }

        public JsonResult getemple()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DEL EMPLEADO
        {
            var lista = empleCN.listaremple();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }


        //[HttpGet]

        //public ActionResult elimina(int? id) //PARA ELIMINAR EL EMPLEADO
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    var empleado = empleCN.detallemple(id.Value);
        //    return View(empleado);

        //}


        [HttpPost]

        public ActionResult elimina(int id)
        {

            try
            {
                empleCN.elimina(id);
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

        [HttpGet]
        public ActionResult editar (int id)//CAPTURAR ALA INFORMACION
        {
            var empleado = empleCN.detallemple(id);
            return View(empleado);

        }

        [HttpPost]
        public ActionResult editar (EMPLEADO empleado)
        {
            try
            {
                empleCN.editar(empleado);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { ok = false, msg = "Error al Editar un Regristro" }, JsonRequestBehavior.AllowGet);
                //return View();
            }
           
        }

    }
}