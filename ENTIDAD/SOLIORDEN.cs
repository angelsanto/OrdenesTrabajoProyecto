//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENTIDAD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SOLIORDEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOLIORDEN()
        {
            this.ORDENTRABAJO = new HashSet<ORDENTRABAJO>();
        }
    
        public int ID_SOLIORDEN { get; set; }

        [DataType(DataType.MultilineText)]
        public string DESCRIPCION { get; set; }
        public Nullable<System.DateTime> FECHASOLI { get; set; }
        public Nullable<int> ID_EMPLE { get; set; }
        public Nullable<byte> ID_CATEGORIA { get; set; }
        public Nullable<byte> ID_DEPARTA { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual TIPOSERVICIO TIPOSERVICIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDENTRABAJO> ORDENTRABAJO { get; set; }
    }
}
