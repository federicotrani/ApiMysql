using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiMysql.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=1234.;database=ites");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumnos);

                entity.ToTable("Alumnos", "DemoMvc");

                entity.Property(e => e.IdAlumnos)
                    .HasColumnName("idAlumnos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasColumnName("domicilio")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Favoritos)
                    .HasColumnName("favoritos")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.ToTable("Usuarios", "DemoMvc");

                entity.Property(e => e.IdUsuarios)
                    .HasColumnName("idUsuarios")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
