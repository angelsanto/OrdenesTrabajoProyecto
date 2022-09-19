using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
  public class MaterialCN
    {
        private static MATERIALDAL obj = new MATERIALDAL();
        public static List<MATERIALES> ListarMaterial() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS.
        {
            return obj.ListarMaterial();
        }

        public static void Agregar(MATERIALES material)
        {
            obj.Agregar(material);
        }

        public static void editar(MATERIALES material)
        {
            obj.editar(material);
        }

        public static MATERIALES detalleMateri(int id)//PARA TRAER EL DETALLE DE LOS REGISTROS
        {
            return obj.detalleMateri(id);
        }

        public static void elimina(int id)//ELIMINA LOS REGISROS.
        {
            obj.elimina(id);
        }
     }
}
