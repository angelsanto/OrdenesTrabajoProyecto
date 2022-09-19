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
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {

            var departamento = DepartaCN.ListarDepart();
            return View(departamento);
        }

        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost] //PARA MANDAR INFORMACION AL SERVIDOR
        [ValidateAntiForgeryToken]
        public ActionResult Crear(DEPARTAMENTO departamento)
        {

            try
            {
                if(departamento.DEPARTAMENTO1==null)
                {
                    return Json(new { ok = false, msg = "Debe de ingresar el Departamento" }, JsonRequestBehavior.AllowGet);
                }

                System.Threading.Thread.Sleep(1000);
                DepartaCN.agregar(departamento);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Error al Agregar un Regristro");
                //return View(departamento);
                return Json(new { ok = false, msg = "Error al Agregar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX

            }

        }

        public ActionResult detalledepa (int id)
        {
            var departamento = DepartaCN.detalledepa(id);
            return View(departamento);

        }
         public JsonResult getdeparta()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DEL CARGO
        {
            var lista = DepartaCN.ListarDepart();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult editar (int id)
        {
            var departamento = DepartaCN.detalledepa(id);
            return View(departamento);
           
        }   

        [HttpPost]
        public ActionResult editar (DEPARTAMENTO departamento)
        {

            try
            {
                System.Threading.Thread.Sleep(1000);
                DepartaCN.editar(departamento);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return RedirectToAction("Index");
            }

            catch(Exception ex)
            {
                //ModelState.AddModelError("", "Error al editar un registro");
                return Json(new { ok = false, msg = "Error al Editar un Regristro" }, JsonRequestBehavior.AllowGet);//REGRESAR EL AJAX
                //return View(departamento);
            }

        }


        //[HttpGet]

        //public ActionResult elimina (int? id)//PARA ELIMINAR
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    var departamento = DepartaCN.detalledepa(id.Value);
        //    return View(departamento);

        //}


        [HttpPost]

        public ActionResult elimina (int id)
        {
            try
            {
                DepartaCN.elimina(id);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //ModelState.AddModelError("", "Error al Eliminar un Regristro");
                return Json(new { ok = false, msg = "Error al Eliminar un Regristro" }, JsonRequestBehavior.AllowGet);
                //return View();
            }

        }
    }
}