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
    
    public partial class TRABAJOSREALIZADOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRABAJOSREALIZADOS()
        {
            this.DETALLEORDEN = new HashSet<DETALLEORDEN>();
        }
    
        public int ID_TRABAJO { get; set; }
        public string TRABAJOS { get; set; }
        public Nullable<byte> ID_CATEGORIA { get; set; }
    
        public virtual TIPOSERVICIO TIPOSERVICIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLEORDEN> DETALLEORDEN { get; set; }
    }
}
