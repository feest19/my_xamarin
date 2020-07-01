using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace firstapi.Entities.Models
{
    public partial class mi_app_xamarinContext : DbContext
    {
        public mi_app_xamarinContext()
        {
        }

        public mi_app_xamarinContext(DbContextOptions<mi_app_xamarinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Hamburguesa> Hamburguesa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:miscursos.database.windows.net,1433;Initial Catalog=mi_app_xamarin;Persist Security Info=False;User ID=florenzo;Password=Madre,solo,dos,2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__677F38F5238975F4");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Celular).HasColumnName("celular");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetodoPago)
                    .HasColumnName("metodo_pago")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__factura__6C08ED539FF02829");

                entity.ToTable("factura");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.DescripcionHamburguesa)
                    .HasColumnName("descripcion_hamburguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionCliente)
                    .HasColumnName("direccion_cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetodoPago)
                    .HasColumnName("metodo_pago")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreHamburguesa)
                    .HasColumnName("nombre_hamburguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioHamburguesa)
                    .HasColumnName("precio_hamburguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hamburguesa>(entity =>
            {
                entity.HasKey(e => e.IdHamburguesa)
                    .HasName("PK__hamburgu__917D5D7A34475E27");

                entity.ToTable("hamburguesa");

                entity.Property(e => e.IdHamburguesa).HasColumnName("id_hamburguesa");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(59)
                    .IsUnicode(false);

                entity.Property(e => e.NombreHamurguesa)
                    .HasColumnName("nombre_hamurguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioHamburguesa)
                    .HasColumnName("precio_hamburguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentacionHamburguesa)
                    .HasColumnName("presentacion_hamburguesa")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
