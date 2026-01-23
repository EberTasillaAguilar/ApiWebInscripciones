using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIInscripcionesChota.Models
{
    public class Administrativo
    {
        [Key]
        public int Id_Administrativo { get; set; } 

        [Required, MaxLength(80)]
        public string Nombres { get; set; }

        [Required, MaxLength(80)]
        public string Apellidos { get; set; }

        [Required, MaxLength(8)]
        public string DNI { get; set; }

        [Required, EmailAddress]
        [MaxLength(120)]
        public string Correo { get; set; }

        [MaxLength(15)]
        public string Celular { get; set; }

        [MaxLength(80)]
        public string Cargo { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        [Required] 
        public int Id_Usuario_Rol { get; set; }

        
        [ForeignKey("Id_Usuario_Rol")]
        public Usuario_Rol UsuarioRol { get; set; } 
    }
}
