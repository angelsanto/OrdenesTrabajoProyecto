using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class UsuariosCN
    {
        private static USUARIOSDAL obj = new USUARIOSDAL();

        public static List<AspNetUsers> ListarUsu() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS
        {
            return obj.ListarUsu();
        }
    }
}
