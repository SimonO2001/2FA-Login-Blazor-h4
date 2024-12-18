﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoftwareTest.ModelsTodo;

public partial class TodoContext : DbContext
{
    public TodoContext()
    {
    }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cpr> Cprs { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Todo;User Id=sa;Password=humanTRIPholland33;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cpr>(entity =>
        {
            entity.HasKey(e => e.CprNr);

            entity.ToTable("Cpr");

            entity.Property(e => e.CprNr).HasMaxLength(500);
            entity.Property(e => e.User).HasMaxLength(200);
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.UserId); // Kun UserId som primær nøgle

            entity.Property(e => e.Item)
                .IsRequired()
                .HasMaxLength(500); // Gør Item til en almindelig egenskab, stadig obligatorisk

            entity.ToTable("Todolist");

            entity.Property(e => e.UserId).HasMaxLength(500);

            entity.HasOne(d => d.User).WithMany(p => p.Todolists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Todolist_Cpr");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
