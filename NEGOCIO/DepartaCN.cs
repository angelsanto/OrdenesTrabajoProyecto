using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DATOS;
namespace NEGOCIO
{
   public class DepartaCN
    {

        private static DEPARTADAL obj = new DEPARTADAL();


        public static void agregar(DEPARTAMENTO departamento)//AGREGAR
        {

            obj.agregar(departamento);
        }

        public static List<DEPARTAMENTO> ListarDepart()
        {
            return obj.ListarDepart();
        }



        public static DEPARTAMENTO detalledepa(int id)

        {
            return obj.detalledepa(id);

        }

        public static void editar (DEPARTAMENTO departamento)
        {
            obj.editar(departamento);
        }

        public static void elimina (int id)
        {
            obj.elimina(id);
        }

        }
}
