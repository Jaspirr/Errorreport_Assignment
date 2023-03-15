﻿using Errorreport_Assignment.MVVM.Model.Entitites;
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
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ErrorReportEntity> ErrorReports { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jesper\Documents\sql_db_NewNewErrorReport.mdf;Integrated Security=True;Connect Timeout=30");
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