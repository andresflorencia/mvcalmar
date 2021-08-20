using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaMVC.Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string usuario { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string clave { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme contraseña")]
        [Compare("clave", ErrorMessage ="Las contraseñas no coinciden")]
        public string confirmaclave { get; set; }
        public int edad { get; set; }
    }
}