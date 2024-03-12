//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRACTICA_AEAE_3_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLCLIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLCLIENTES()
        {
            this.TBLFACTURA = new HashSet<TBLFACTURA>();
        }
        
        [Key]
        public int IdCliente { get; set; }
        [Display(Name = "Nombre")]
        public string StrNombre { get; set; }
        [Display(Name = "Nro Documento")]
        public Nullable<long> NumDocumento { get; set; }
        [Display(Name = "Direccion")]
        public string StrDireccion { get; set; }
        [Display(Name = "Telefono")]
        public string StrTelefono { get; set; }
        [Display(Name = "Correo")]
        public string StrEmail { get; set; }
        public Nullable<System.DateTime> DtmFechaModifica { get; set; }
        public string StrUsuarioModifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFACTURA> TBLFACTURA { get; set; }
    }
}
