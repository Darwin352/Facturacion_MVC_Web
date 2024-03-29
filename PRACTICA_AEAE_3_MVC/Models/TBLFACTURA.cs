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

    public partial class TBLFACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLFACTURA()
        {
            this.TBLDETALLE_FACTURA = new HashSet<TBLDETALLE_FACTURA>();
        }
    
        [Key]
        public int IdFactura { get; set; }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DtmFecha { get; set; }
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        [Display(Name = "Empleado")]
        public int IdEmpleado { get; set; }
        [Display(Name = "Descuento")]
        public Nullable<double> NumDescuento { get; set; }
        [Display(Name = "Impuesto")]
        public Nullable<double> NumImpuesto { get; set; }
        [Display(Name = "Valor Total")]
        public Nullable<double> NumValorTotal { get; set; }
        [Display(Name = "Estado")]
        public Nullable<int> IdEstado { get; set; }
        public Nullable<System.DateTime> DtmFechaModifica { get; set; }
        public string StrUsuarioModifica { get; set; }
    
        public virtual TBLCLIENTES TBLCLIENTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLDETALLE_FACTURA> TBLDETALLE_FACTURA { get; set; }
        public virtual TBLEMPLEADO TBLEMPLEADO { get; set; }
        public virtual TBLESTADO_FACTURA TBLESTADO_FACTURA { get; set; }
    }
}
