using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{

    //CAPA DE NEGOCIOS ES PARA TENER UNA COMUNICACION CON LA CAPA DE ENTIDAD Y LA CAPA DE DATOS Y LLAMAR LAS ACCIONES DE LA CAPA DE DATOS PARA LAS ACCIONES DEL CRUD.
  public  class CargoCN
    {
        private static CARGODAL obj = new CARGODAL();


        public static void Agregar(CARGO cargo)
        {
            obj.Agregar(cargo);

        }

        public static List<CARGO> ListarCargo() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS
        {
            return obj.ListarCargo();
        }

        public static CARGO detalleCargo(int id)//PARA TRAER EL DETALLE DE LOS REGISTROS
        {
            return obj.detalleCargo(id);
        }


        public static void editar(CARGO cargo)//ES PARA EDITAR LOS REGISTROS
        {
            obj.editar(cargo);
        }


        public static void elimina(int id)//PARA ELIMINAR REGISTROS
        {
            obj.elimina(id);

        }

        }
}
