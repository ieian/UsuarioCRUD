using System.ComponentModel.DataAnnotations;

namespace UsuarioCRUD.Models
{
    public class Login
    {   
        [Required(ErrorMessage ="Ingrese su usuario correctamente")]
        [Display(Name = "Ingrese su usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ingrese su pass correctamente")]
        [Display(Name = "Ingrese su pass")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
