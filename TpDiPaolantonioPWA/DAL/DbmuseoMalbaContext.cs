using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TpDiPaolantonioPWA.DAL;

public partial class DbmuseoMalbaContext : DbContext
{
    public DbmuseoMalbaContext()
    {
    }

    public DbmuseoMalbaContext(DbContextOptions<DbmuseoMalbaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Obra> Obras { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TipoEvento> TipoEventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.ToTable("autor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.NacionalidadId).HasColumnName("nacionalidad_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Nacionalidad).WithMany(p => p.Autors)
                .HasForeignKey(d => d.NacionalidadId)
                .HasConstraintName("FK_autor_pais");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.ToTable("evento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutorId).HasColumnName("autor_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.DescripcionDetalle)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion_detalle");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.NombreEvento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_evento");
            entity.Property(e => e.Portada)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("portada");
            entity.Property(e => e.SalaId).HasColumnName("sala_id");
            entity.Property(e => e.TipoId).HasColumnName("tipo_id");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.Autor).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evento_autor");

            entity.HasOne(d => d.Sala).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.SalaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evento_sala");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.TipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_evento_tipo_evento");
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nacionalidad");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nacionalidad1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nacionalidad");
        });

        modelBuilder.Entity<Obra>(entity =>
        {
            entity.ToTable("obra");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaObra).HasColumnName("fecha_obra");
            entity.Property(e => e.IdAutor).HasColumnName("id_autor");
            entity.Property(e => e.ImagenObra)
                .HasMaxLength(8000)
                .HasColumnName("imagen_obra");
            entity.Property(e => e.NombreObra)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nombre_obra");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Obras)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_obra_autor");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.ToTable("pais");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.ToTable("sala");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreSala)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nombre_sala");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ticket");

            entity.Property(e => e.CantEntradas).HasColumnName("cant_entradas");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.ValorTotal).HasColumnName("valor_total");

            entity.HasOne(d => d.IdEventoNavigation).WithMany()
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ticket_evento1");
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.ToTable("tipo_evento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
