using ENTIDAD;
using DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class empleCN
    {

        private static EMPLEDAL obj = new EMPLEDAL();



        public static void agregar(EMPLEADO empleado)//AGREGAR
        {

            obj.agregar(empleado);
        }

        public static List<empleadoCE> listaremple()
        {
            return obj.listaremple();

        }


        public static empleadoCE detallemple(int id)

        {
            return obj.detallemple(id);

        }

        public static void elimina(int id)
        {
            obj.elimina(id);
        }

        public static void editar(EMPLEADO empleado)
        {
            obj.editar(empleado);
        }
        }
    }
