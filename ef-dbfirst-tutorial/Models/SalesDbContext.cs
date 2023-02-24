using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ef_dbfirst_tutorial.Models;

public partial class SalesDbContext : DbContext
{
    public SalesDbContext()
    {
    }

    public SalesDbContext(DbContextOptions<SalesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb;trusted_connection=true;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0763319709");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Sales).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0778063FEF");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(80);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__286302EC");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderLin__3214EC07111E2EF0");

            entity.Property(e => e.Description).HasMaxLength(80);
            entity.Property(e => e.Price)
                .HasDefaultValueSql("((10))")
                .HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Product).HasMaxLength(30);
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderLine__Order__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
