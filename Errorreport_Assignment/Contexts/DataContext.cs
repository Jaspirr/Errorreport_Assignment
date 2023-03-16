using Errorreport_Assignment.MVVM.Model.Entitites;
using Errorreport_Assignment.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Xml;


namespace Errorreport_Assignment.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DataContext()
    {
    }

    public DbSet<CustomerEntity> CustomerModels { get; set; }
    public DbSet<ErrorReportEntity> ErrorReportModels { get; set; }
    public DbSet<CommentEntity> CommentModels { get; set; }
    public DbSet<WorkerEntity> WorkersModels { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jesper\Documents\sql_db_ErrorReportNewest.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CustomerEntity>().ToTable("Customer");
        modelBuilder.Entity<ErrorReportEntity>().ToTable("ErrorReport");
        modelBuilder.Entity<CommentEntity>().ToTable("Comments");

        modelBuilder.Entity<ErrorReportEntity>()
            .HasOne(e => e.Customer)
            .WithMany(c => c.ErrorReport)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.ErrorReport)
            .WithMany(e => e.Comments)
            .HasForeignKey(c => c.ErrorReportId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
