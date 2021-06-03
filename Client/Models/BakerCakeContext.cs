using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BakerCakeClient.Models
{
    public partial class BakerCakeContext : DbContext
    {
        public BakerCakeContext()
        {
        }

        public BakerCakeContext(DbContextOptions<BakerCakeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CakeDetail> CakeDetails { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BakerCake;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CakeDetail>(entity =>
            {
                entity.HasKey(e => e.CakeId)
                    .HasName("PK__CakeDeta__C56DBF156629B78C");

                entity.Property(e => e.CakeDescription).IsUnicode(false);

                entity.Property(e => e.CakeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Order_De__C3905BCF1B031B58");

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CakeId)
                    .HasConstraintName("FK__Order_Det__CakeI__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Order_Det__UserI__5629CD9C");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4C24B41B78");

                entity.HasIndex(e => e.UserEmail, "UQ__UserDeta__08638DF87718E74A")
                    .IsUnique();

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserContact)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserDetai__RoleI__52593CB8");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__UserRole__8AFACE1A517A4415");

                entity.ToTable("UserRole");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
