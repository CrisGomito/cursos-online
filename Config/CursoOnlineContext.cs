using System;
using System.Collections.Generic;
using Cursos_Online.Modelos;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Cursos_Online.Config;

public partial class CursoOnlineContext : DbContext
{
    public CursoOnlineContext()
    {
    }

    public CursoOnlineContext(DbContextOptions<CursoOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=cursos_online;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PRIMARY");

            entity.Property(e => e.Capacidad).HasComment("Cantidad máxima de estudiantes (NULL = sin límite)");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasComment("1=Activo,0=Inactivo");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.Precio).HasDefaultValueSql("'0.00'");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Cursos)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_cursos_profesor");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PRIMARY");

            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasComment("1=Activo,0=Inactivo (eliminación lógica)");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.InscripcionId).HasName("PRIMARY");

            entity.Property(e => e.Estado).HasDefaultValueSql("'Inscripto'");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.Nota).HasComment("Calificación final (opcional)");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones).HasConstraintName("fk_inscripciones_curso");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Inscripciones).HasConstraintName("fk_inscripciones_estudiante");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.ProfesorId).HasName("PRIMARY");

            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasComment("1=Activo,0=Inactivo (eliminación lógica)");
            entity.Property(e => e.FechaActualizacion)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("current_timestamp()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
