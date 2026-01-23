using Microsoft.AspNetCore.Http.Timeouts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIInscripcionesChota.Models
{
    public class Pago
    {
        [Key]
        public int Id_Pago { get; set; }

        [Required]
        public int Id_Tarifa { get; set; }

        [Required, MaxLength(255)]
        public string Codigo_Voucher { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Imagen_Voucher { get; set; }

        [Required, MaxLength(20)]
        public string Estado { get; set; }

        // Relaciones
        [ForeignKey("Id_Tarifa")]
        public Tarifa Tarifa
        {
            get; set;

        }
        [ForeignKey("Id_Pago")]
        public Postulante postulante { get; set; }
    }
}
