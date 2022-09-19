using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORDENESDTRABAJO.Controllers
{
    //[AllowAnonymous]
    public class OrdenController : Controller
    {
        // GET: Orden
        public ActionResult Index()
        {
            var orden = OrdenCN.listarOrden();
            return View(orden);
            //return View();
        }


        public JsonResult getorden()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX ORDEN
        {
            var lista = OrdenCN.listarOrde();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ORDENTRABAJO orden)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                OrdenCN.agregar(orden);
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


        public ActionResult detalleorden(int id)//CAPTURAR ALA INFORMACION
        {
            var orden = OrdenCN.detalleorden(id);
            return View(orden);

        }



        [HttpGet]
        public ActionResult editar(int id)//CAPTURAR ALA INFORMACION
        {
            var orden = OrdenCN.detalleorden(id);
            return View(orden);

        }

        [HttpPost]
        public ActionResult editar(ORDENTRABAJO orden)
        {
            try
            {
                OrdenCN.editar(orden);
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
                OrdenCN.elimina(id);
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

    }

    }

    
