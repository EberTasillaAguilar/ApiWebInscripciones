using System.ComponentModel.DataAnnotations;

namespace APIInscripcionesChota.Models
{
    public class Usuario_Rol
    {
        [Key]
        public int Id_Usuario_Rol { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreRol { get; set; }

        [Required]
        [MaxLength(60)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]    
        public string Password { get; set; }

        // Relaciones
        public Postulante? Postulante { get; set; }
        public Administrativo? Administrativo { get; set; }
    }
}
