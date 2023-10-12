using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _201012_API1.Models;

public partial class ClasesContext : DbContext
{
    public ClasesContext()
    {
    }

    public ClasesContext(DbContextOptions<ClasesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=L302-14\\SQLEXPRESS; Database=CLASES;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);

            entity.ToTable("ALUMNO");

            entity.Property(e => e.IdAlumno).HasColumnName("ID_ALUMNO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdAsignatura).HasColumnName("ID_ASIGNATURA");
            entity.Property(e => e.NombreAlumno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ALUMNO");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALUMNO_ASIGNATURA");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura);

            entity.ToTable("ASIGNATURA");

            entity.Property(e => e.IdAsignatura).HasColumnName("ID_ASIGNATURA");
            entity.Property(e => e.NomAsignatura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_ASIGNATURA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
