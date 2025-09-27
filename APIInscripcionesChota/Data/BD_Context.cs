using Microsoft.EntityFrameworkCore;
namespace APIIncripccionesChota.Data

{
    public class BD_Context: DbContext
    {
        public BD_Context(DbContextOptions<BD_Context> options): base(options) { 
        }
        // Definición de las tablas
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Pre> PregradoCertificados { get; set; }
        public DbSet<Pago> CentroIdiomas { get; set; }
        public DbSet<Pago> PregradoTasas { get; set; }
        public DbSet<Pago> Cepunc { get; set; }

        // Configuración del modelo, opcionalmente se puede hacer con Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para la tabla de 'Pagos'
            modelBuilder.Entity<Pago>()
                .ToTable("Pagos");

            // Configuración de los otros tipos de pagos si es necesario
            modelBuilder.Entity<Pago>()
                .ToTable("PregradoCertificados");

            modelBuilder.Entity<Pago>()
                .ToTable("CentroIdiomas");

            modelBuilder.Entity<Pago>()
                .ToTable("PregradoTasas");

            modelBuilder.Entity<Pago>()
                .ToTable("Cepunc");

            // Si deseas relaciones más complejas, podrías hacer algo similar
            // ejemplo, si se tuvieran otras relaciones entre las tablas:
            // modelBuilder.Entity<Pago>()
            //    .HasOne(o => o.AlgunaOtraEntidad)
            //    .WithMany()
            //    .HasForeignKey(f => f.AlgunaClaveForanea);
        }
    }
}
