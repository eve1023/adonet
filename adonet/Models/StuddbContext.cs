using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace adonet.Models;

public partial class StuddbContext : DbContext
{
    public StuddbContext()
    {
    }

    public StuddbContext(DbContextOptions<StuddbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=studdb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC07E8E375E7");

            entity.Property(e => e.Curator)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07A3C0DBDB");

            entity.ToTable("Student");

            entity.Property(e => e.IdGroup).HasColumnName("id_group");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Year).HasColumnType("date");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Student__id_grou__4AB81AF0");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC070D14D79C");

            entity.ToTable("Subject");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdGroup).HasColumnName("id_group");
            entity.Property(e => e.Lecturer).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Subject__id_grou__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
