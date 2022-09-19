using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class ManateCN
    {
        private static MANTEDAL obj = new MANTEDAL();
        public static List<MANTENIMIENTO> Listarmante() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS
        {
            return obj.Listarmante();
        }
    }
}
