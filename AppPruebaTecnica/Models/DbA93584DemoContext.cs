using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppPruebaTecnica.Models;

public partial class DbA93584DemoContext : DbContext
{
    public DbA93584DemoContext()
    {
    }

    public DbA93584DemoContext(DbContextOptions<DbA93584DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Editoriale> Editoriales { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Tabla> Tablas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioTipo> UsuarioTipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql5104.site4now.net; database=db_a93584_demo; User id=db_a93584_demo_admin; Password=Eb4sdW,(Uc;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AutoresHasLibro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Autores_has_libros");

            entity.Property(e => e.AutoresId).HasColumnName("autores_id");
            entity.Property(e => e.LibrosId).HasColumnName("libros_id");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("clientes");

            entity.Property(e => e.Accion)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("accion");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Editoriale>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sede)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sede");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.Property(e => e.EditorialesId).HasColumnName("editoriales_id");
            entity.Property(e => e.NPaginas)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_paginas");
            entity.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Tabla>(entity =>
        {
            entity.ToTable("tabla");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoId).HasColumnName("tipo_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK_Usuarios_tipos");
        });

        modelBuilder.Entity<UsuarioTipo>(entity =>
        {
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
