using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class AutenticacionModel 
    {

        public string usuario { get; set; }
        public string pass { get; set; }
    }


    public class Registro {
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }


        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string mail { get; set; }


        [Required]
        [Display(Name = "Edad")]
        public int edad { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} characteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "No coincide.")]
        public string ConfirmPassword { get; set; }




    }

    

    public class AsignarRoles
    {
        [Required]
        [Display(Name = "Nombre")]
        public String nombreUsuario { get; set; }


        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string mail { get; set; }


        [Required]
        [Display(Name = "Edad")]
        public int edad { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public List<int> roleId { get; set; }


    }
    public class MenuModel
    {
        public string descripcion { get; set; }

        public string actionName { get; set; }
        public string controllerName { get; set; }
        public string roles { get; set; }
    }
}