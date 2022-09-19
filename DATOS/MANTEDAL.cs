using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
   public class MANTEDAL
    {

        public List<MANTENIMIENTO> Listarmante() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {

               db.Configuration.LazyLoadingEnabled = false;//PARA QUE NO TRAIGA LOS DATOS DEL EPLEADO YA QUE TIENE UN RELACION CON ESA TABLA PARA LLENAR EL DROPDONLIST
                return db.MANTENIMIENTO.ToList();

            }

        }
    }
}
