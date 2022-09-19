using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
  public class detalleCE
    {
        public int ID_DETALLE { get; set; }
        public int ID_ORDEN { get; set; }
        public int ID_TRABAJO { get; set; }
        public string TRABAJOS { get; set; }
        public Nullable<int> ID_MATERIAL { get; set; }
        public string METERIAL { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public string OBSERVACION { get; set; }
    }
}
