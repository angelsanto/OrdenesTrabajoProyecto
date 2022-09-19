using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
   public class USUARIOSDAL
    {
        public List<AspNetUsers> ListarUsu() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                return db.AspNetUsers.ToList();

            }

        }

    }
}
