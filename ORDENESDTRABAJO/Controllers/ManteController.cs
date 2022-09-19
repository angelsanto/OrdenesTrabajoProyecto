using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORDENESDTRABAJO.Controllers
{
    public class ManteController : Controller
    {
        // GET: Mante
        public ActionResult Index()
        {

            var mante = ManateCN.Listarmante();
            return View(mante);
            //return View();
        }

        public JsonResult getmante()//LLAMA A LA FUNCION PARA LLENAR EL CONBOBOX DEL MANTENIMINTO
        {
            var lista = ManateCN.Listarmante();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }
    }
}