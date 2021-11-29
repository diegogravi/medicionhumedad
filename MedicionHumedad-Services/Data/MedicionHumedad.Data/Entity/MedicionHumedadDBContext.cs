
namespace MedicionHumedad.Data.Entity
{
    using Microsoft.EntityFrameworkCore;
    using MedicionHumedad.Data.Models;

    public partial class MedicionHumedadDBContext : DbContext
    {
        public MedicionHumedadDBContext()
        {
        }

        public MedicionHumedadDBContext(DbContextOptions<MedicionHumedadDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fruto> Fruto { get; set; }
        public virtual DbSet<Medicion> Medicion { get; set; }
        public virtual DbSet<Plantacion> Plantacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-DIEGO;Database=MedicionHumedadDB;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruto>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Medicion>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(150);

                entity.Property(e => e.Porcentaje).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Fruto)
                    .WithMany(p => p.Medicion)
                    .HasForeignKey(d => d.FrutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicion_Fruto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Medicion)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicion_Usuario");
            });

            modelBuilder.Entity<Plantacion>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasOne(d => d.Plantacion)
                    .WithMany(p => p.Sensor)
                    .HasForeignKey(d => d.PlantacionId)
                    .HasConstraintName("FK_Sensor_Plantacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("GUID")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.HasOne(d => d.Plantacion)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PlantacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Plantacion");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
