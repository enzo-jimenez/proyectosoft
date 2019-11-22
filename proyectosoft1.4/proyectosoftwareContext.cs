using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using proyectosoft1._4.Models;

namespace proyectosoft1._4
{
    public partial class proyectosoftwareContext : DbContext
    {
        public proyectosoftwareContext()
        {
        }

        public proyectosoftwareContext(DbContextOptions<proyectosoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Comercio> Comercio { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7SC2H20\\PROYECTOSOFTSQL;Initial Catalog=proyectosoftware;Integrated Security=True;MultipleActiveResultSets=True", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Comercio>(entity =>
            {
                entity.HasKey(e => e.ComId);

                entity.Property(e => e.ComId)
                    .HasColumnName("comId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComDescripcion)
                    .IsRequired()
                    .HasColumnName("comDescripcion");

                entity.Property(e => e.ComDireccion)
                    .IsRequired()
                    .HasColumnName("comDireccion");

                entity.Property(e => e.ComNombre)
                    .IsRequired()
                    .HasColumnName("comNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.ComProId)
                    .HasColumnName("comProId")
                    .HasMaxLength(450);

                entity.Property(e => e.ComUbId)
                    .HasColumnName("comUbID")
                    .HasMaxLength(450);

                entity.Property(e => e.ComUbicacion).HasColumnName("comUbicacion");

                entity.Property(e => e.ComUsId)
                    .HasColumnName("comUsId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.ComPro)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.ComProId)
                    .HasConstraintName("FK_Comercio_Producto");

                entity.HasOne(d => d.ComUb)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.ComUbId)
                    .HasConstraintName("FK_Comercio_Ubicacion");

                entity.HasOne(d => d.ComUs)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.ComUsId)
                    .HasConstraintName("FK_Comercio_AspNetUsers");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.Property(e => e.ProId)
                    .HasColumnName("proId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProDescripcion).HasColumnName("proDescripcion");

                entity.Property(e => e.ProDisponible).HasColumnName("proDisponible");

                entity.Property(e => e.ProNombre)
                    .IsRequired()
                    .HasColumnName("proNombre")
                    .HasMaxLength(50);

                entity.Property(e => e.ProPrecio)
                    .HasColumnName("proPrecio")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.UbId);

                entity.Property(e => e.UbId)
                    .HasColumnName("ubID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UbUbicacion).HasColumnName("ubUbicacion");
            });
        }
    }
}
