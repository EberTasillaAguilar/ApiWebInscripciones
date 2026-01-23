namespace APIInscripcionesChota.Dtos
{
    public class CrearPagoDto
    {
        public int Id_Tarifa { get; set; }
        public string Codigo_Voucher { get; set; }

        // La imagen que viene desde el celular (archivo real)
        public IFormFile? FotoVoucher { get; set; }
    }
}
