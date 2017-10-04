//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReviewSoftMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.RETROALIMENTACION = new HashSet<RETROALIMENTACION>();
        }
    
        public int CODIGO { get; set; }

        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string CORREO { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string CONTRASEÑA { get; set; }

        [Display(Name = "Tipo de Cuenta")]
        public int TIPO_USUARIO { get; set; }

        [Display(Name = "Profesion")]
        public int PROFESION { get; set; }
    
        public virtual PROFESION PROFESION1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RETROALIMENTACION> RETROALIMENTACION { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO1 { get; set; }
    }
}
