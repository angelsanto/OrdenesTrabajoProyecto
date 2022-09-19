using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
   public class tablatempoCE
    {
        //public int ID_DETALLE_ORDEN { get; set; }
        public int ID_ORDEN { get; set; }
        public int ID_TRABAJO_ORDEN { get; set; }
        public string TRABAJOS { get; set; }
        public int ID_MATERIAL_ORDEN { get; set; }
        public string METERIAL { get; set; }
        public int CANTIDAD_ORDEN { get; set; }
        public string OBSERVACIONES_ORDEN { get; set; }
        public string C_GUID { get; set; }

    }
}
