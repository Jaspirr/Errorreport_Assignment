using Errorreport_Assignment.MVVM.Model.Entitites;
using Errorreport_Assignment.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Xml;


namespace Errorreport_Assignment.Contexts;

public class DataContext : DbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ErrorReportEntity> ErrorReports { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<WorkerEntity> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ErrorReportDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CustomerEntity>()
            .HasMany(c => c.ErrorReports)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId);

        modelBuilder.Entity<CustomerEntity>()
            .HasIndex(nameof(CustomerEntity.EmailAddress))
            .IsUnique();

        modelBuilder.Entity<ErrorReportEntity>()
            .HasOne(e => e.Customer)
            .WithMany(c => c.ErrorReports)
            .HasForeignKey(e => e.CustomerId);
    }
}
