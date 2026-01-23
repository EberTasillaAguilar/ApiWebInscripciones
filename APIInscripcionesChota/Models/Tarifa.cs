using System.ComponentModel.DataAnnotations;

namespace APIInscripcionesChota.Models
{
    public class Tarifa
    {
        [Key]
        public int Id_Tarifa { get; set; }

        [Required, MaxLength(150)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Monto { get; set; }

        // Relación
        public ICollection<Pago> Pagos { get; set; }
    }
}
