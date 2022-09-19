using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
  public class solicitudCE
    {
        public int ID_SOLIORDEN { get; set; }

        public string DESCRIPCION { get; set; }
        public Nullable<System.DateTime> FECHASOLI { get; set; }
        public Nullable<int> ID_EMPLE { get; set; }
        public string NON { get; set; }
        public string APELLIDO { get; set; }
        public string nombreCompleto { get { return $"{NON} {APELLIDO}"; } }
        public Nullable<byte> ID_CATEGORIA { get; set; }
        public string CATEGORIA { get; set; }
        public Nullable<byte> ID_DEPARTA { get; set; }
        public string DEPARTAMENTO { get; set; }
       
    }
}
