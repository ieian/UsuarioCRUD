using System.ComponentModel.DataAnnotations;

namespace UsuarioCRUD.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(80)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(80)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(12)]
        public string Telefono { get; set; }

        [Required]
        public int CodigoP { get; set; }

        [Required]
        [MaxLength(40)]
        public string Tipo_Usuario { get; set; }

        [Required]
        [MaxLength(40)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(40)]
        public string Ciudad { get; set; }
    }
}
