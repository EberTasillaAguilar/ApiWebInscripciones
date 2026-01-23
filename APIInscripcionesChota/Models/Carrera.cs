using System.ComponentModel.DataAnnotations;

namespace APIInscripcionesChota.Models
{
    public class Carrera
    {
        [Key]
        public int Id_Carrera { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(100)]
        public string Facultad { get; set; }

        [MaxLength(100)]
        public string Escuela { get; set; }

        [MaxLength(100)]
        public string Sede { get; set; }

        // Relación
        public ICollection<Postulante> Postulantes { get; set; }
    }
}
