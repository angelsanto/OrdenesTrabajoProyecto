using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
  public class VistaDCN
    {
        private static DETALLEVISTADAL obj = new DETALLEVISTADAL();

        public static List<detalleCE> listadetalle()
        {
            return obj.listadetalle();

        }

        public static List<DETALLEORDEN> lista(int id)
        {
            return obj.lista(id);
        }
        //PARA MOSTRAR TABLA TEMPORAL
        //public static List<tablatempoCE> listadetalletemp()
        //{
        //    return obj.listadetalletemp();

            //}

            //GUARDAR A TABLA TEMPO
        //public static void Agregar(int idorden, int idtrabajo, int idmaterial, int cantidad, string observacion, string guiI)
        //{
        //    obj.Agregar(idorden, idtrabajo, idmaterial, cantidad, observacion, guiI);
        //}

        public static void elimina(int id)
        {
            obj.elimina(id);
        }


        //AGREGAR DETALLE A LA ORDEN
        public static void guardarDT(DETALLEORDEN[] detalle)
        {
            obj.guardarDT(detalle);
        }
    }
}
