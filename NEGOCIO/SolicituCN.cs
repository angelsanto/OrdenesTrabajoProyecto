using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class SolicituCN
    {
        private static SOLICITUDAL obj = new SOLICITUDAL();


        public static List<solicitudCE> ListarSoli()
        {
            return obj.ListarSoli();
        }

        public static List<solicitudCE> ListarSolicitud()
        {
            return obj.ListarSolicitud();
        }

        public static solicitudCE detallesoli(int id)//DETALLE
        {
            return obj.detallesoli(id);
        }

        public static void agregar(SOLIORDEN solicitud)//AGREGAR
        {

            obj.agregar(solicitud);
        }


        public static void elimina(int id)
        {
            obj.elimina(id);
        }
    }
    }
