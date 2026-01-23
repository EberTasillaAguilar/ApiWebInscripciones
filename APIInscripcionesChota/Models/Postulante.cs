using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIInscripcionesChota.Models
{
    public class Postulante
    {
        [Key]
        public int Id_Postulante { get; set; } 

        [Required, MaxLength(80)]
        public string Nombres { get; set; }

        [Required, MaxLength(80)]
        public string Apellidos { get; set; }

        [Required, MaxLength(8)]
        public string DNI { get; set; }

        [Required, EmailAddress]
        [MaxLength(120)]
        public string Correo { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        [Required]
        public int Id_Carrera { get; set; }

        [Required, MaxLength(50)]
        public string Modalidad { get; set; }

        [Required, MaxLength(20)]
        public string Periodo_Inscripción { get; set; }

        [MaxLength(50)]
        public string Tipo_Colegio { get; set; }

       
        [Required] 
        public int Id_Usuario_Rol { get; set; }

        [Required]
        public int Id_Pago { get; set; }

        // Relaciones
        [ForeignKey("Id_Carrera")]
        public Carrera Carrera { get; set; }

        [ForeignKey("Id_Usuario_Rol")]
        public Usuario_Rol Usuario_Rol { get; set; } // Propiedad de navegación a su Usuario_Rol

        [ForeignKey("Id_Pago")]
        public Pago Pago { get; set; }
    }
}
