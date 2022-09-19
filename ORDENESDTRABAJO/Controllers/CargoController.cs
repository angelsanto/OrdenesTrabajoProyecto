using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ORDENESDTRABAJO.Controllers
{

   
    public class CargoController : Controller
    {
        // GET: Cargo
        public ActionResult Index()  //MANDA A LLAMAR LA LISTA.
        {
            var cargo = CargoCN.ListarCargo();
            return View(cargo);
        }

        [HttpGet]
        public ActionResult Crear()//SOLICITA LA VISTA PARA CREAR UN NUENO REGISTRO.
        {

            return View();
        }

       
        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
        [ValidateAntiForgeryToken]
        public ActionResult Crear(CARGO cargo)
        {          

            try
            {
                if(cargo.CARGO1==null)
                {
                    return Json(new { ok = false, msg = "Debe de ingresar el Cargo" }, JsonRequestBehavior.AllowGet);
                }


                System.Threading.Thread.Sleep(1000);
                CargoCN.Agregar(cargo);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(cargo);
                return Json(new { ok = false, msg= "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }

        }

        public ActionResult Cargodetalle(int id)
        {
            var cargo = CargoCN.detalleCargo(id);
            return View(cargo);
        }


        public JsonResult getcargos()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DEL CARGO
        {
            var lista = CargoCN.ListarCargo();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult editar(int id)//SOLICITA LA VISTA PARA EDITAR UN NUENO REGISTRO.
        {
           
            var cargo = CargoCN.detalleCargo(id);
            return View(cargo);
        }

        [HttpPost]
        public ActionResult editar(CARGO cargo)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                CargoCN.editar(cargo);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Editar un Regristro");
                //return View(cargo);
                return Json(new { ok = false, msg = "Error al Editar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }
        }


        //[HttpGet]
        //public ActionResult elimina(int? id)//SOLICITA LA VISTA PARA CREAR UN NUENO REGISTRO.
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var dl = CargoCN.detalleCargo(id.Value);
        //    return View(dl);

        //}

        [HttpPost]
        public ActionResult elimina(int id)
        {

            try
            {
                
                CargoCN.elimina(id);
                //return RedirectToAction("Index");
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

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