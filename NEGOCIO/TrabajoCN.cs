using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DATOS;

namespace NEGOCIO
{
   public class TrabajoCN
    {
        private static TRABAJODAL obj = new TRABAJODAL();
        public static List<trabajoCE> ListarTrabajo()
        {
            return obj.ListarTrabajo();
        }

        //PARA HACER EL SELECT CASCADA.
        public static List<TRABAJOSREALIZADOS> ListarTraba(int ID_CATEGO)
        {
            return obj.ListarTraba(ID_CATEGO);
        }

        public static void agregar(TRABAJOSREALIZADOS trabajo)//AGREGAR UTILIZANDO LINQ.
        {
            obj.agregar(trabajo);
        }

        public static void elimina(int id)
        {
            obj.elimina(id);
        }

        public static void editar(TRABAJOSREALIZADOS trabajo)
        {
            obj.editar(trabajo);
        }
        public static trabajoCE detalletrabajo(int id)

        {
            return obj.detalletrabajo(id);

        }
    }
    }
