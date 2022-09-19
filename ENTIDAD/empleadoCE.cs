using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{

    //PARA QUE ME MUSTRE EN LA LISTA LOS CAMPOS UNIDOS DE NOMBRES Y EL NOMBRE DEL CARGO Y DEPARTAMENTO
  public class empleadoCE
    {
        public int ID_EMPLE { get; set; }
        public string DNI { get; set; }
        public string NON { get; set; }
        public string APELLIDO { get; set; }
        public string nombreCompleto { get { return $"{NON} {APELLIDO}"; } }
        public Nullable<byte> ID_CARGO { get; set; }
        public string CARGO { get; set; }
        public Nullable<byte> ID_DEPARTA { get; set; }
        public string DEPARTAMENTO { get; set; }
    }
}
