using Microsoft.EntityFrameworkCore;

namespace ProyectoAlvaro.Models
{
    public partial class DbproyectoContext : DbContext
    {
        public DbproyectoContext()
        {
        }

        public DbproyectoContext(DbContextOptions<DbproyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF9786D11CA2");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Clave)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
