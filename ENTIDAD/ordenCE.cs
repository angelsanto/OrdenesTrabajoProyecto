using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
  public class ordenCE
    {
        public int ID_ORDEN { get; set; }
        public Nullable<System.DateTime> FECHAINICIO { get; set; }
        public Nullable<System.DateTime> FECHAFINAL { get; set; }
        public Nullable<int> ID_EMPLE { get; set; }
        public string NON { get; set; }
        public string APELLIDO { get; set; }
        public string nombreCompleto { get { return $"{NON} {APELLIDO}"; } }
        public Nullable<byte> ID_MANTENI { get; set; }
        public string mantenimiento { get; set; }
        public Nullable<int> ID_SOLIORDEN { get; set; }
        public string DESCRIPCION { get; set; }


    }
}
