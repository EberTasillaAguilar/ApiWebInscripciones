using APIInscripcionesChota.Models;
using Microsoft.EntityFrameworkCore;
namespace APIIncripccionesChota.Data

{
    public class BD_Context: DbContext
    {
        public BD_Context(DbContextOptions<BD_Context> options): base(options) { 
        }
        // Definición de las tablas
        public DbSet<Postulante> Postulantes { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Usuario_Rol> Usuario_Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Pago -> Tarifa (1:N)
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Tarifa)
                .WithMany(t => t.Pagos)
                .HasForeignKey(p => p.Id_Tarifa);

            // Postulante -> Carrera
            modelBuilder.Entity<Postulante>()
                .HasOne(p => p.Carrera)
                .WithMany(c => c.Postulantes)
                .HasForeignKey(p => p.Id_Carrera);

            modelBuilder.Entity<Usuario_Rol>()
               .HasOne(ur => ur.Postulante)      
               .WithOne(p => p.Usuario_Rol)      
               .HasForeignKey<Postulante>(p => p.Id_Usuario_Rol) 
               .IsRequired(false);

            // Usuario_Rol <-> Administrativo (1:1 opcional)
            modelBuilder.Entity<Usuario_Rol>()
                .HasOne(ur => ur.Administrativo)
                .WithOne(a => a.UsuarioRol)
                .HasForeignKey<Administrativo>(a => a.Id_Usuario_Rol)
                .IsRequired(false);

            // Postulante -> Pago (opcional)
            modelBuilder.Entity<Postulante>()
                .HasOne(p => p.Pago)
                .WithMany()
                .HasForeignKey(p => p.Id_Pago)
                .IsRequired(false);
        }

    }
}
