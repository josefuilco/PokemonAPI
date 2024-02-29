using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokemonAPI.Models;

public partial class DbpokeMasterContext : DbContext
{
    public DbpokeMasterContext()
    {
    }

    public DbpokeMasterContext(DbContextOptions<DbpokeMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alimentacion> Alimentaciones { get; set; }

    public virtual DbSet<Caracteristica> Caracteristicas { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<Rareza> Rarezas { get; set; }

    public virtual DbSet<Tamaño> Tamaños { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alimentacion>(entity =>
        {
            entity.HasKey(e => e.IdAlimentacion).HasName("PK__Alimenta__9023BF7F7AE93A3A");

            entity.HasIndex(e => e.ContentAlimentacion, "UQ__Alimenta__8BAA9FD17A4580F6").IsUnique();

            entity.Property(e => e.IdAlimentacion).HasColumnName("idAlimentacion");
            entity.Property(e => e.ContentAlimentacion).HasColumnName("Alimentacion")
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Caracteristica>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristica).HasName("PK__Caracter__F27E521E9AC0E118");

            entity.Property(e => e.IdCaracteristica).HasColumnName("idCaracteristica");
            entity.Property(e => e.IdAlimentacion).HasColumnName("idAlimentacion");
            entity.Property(e => e.IdTamaño).HasColumnName("idTamaño");
            entity.Property(e => e.Peso).HasColumnType("decimal(4, 1)");

            entity.HasOne(d => d.AlimentacionData).WithMany(p => p.Caracteristicas)
                .HasForeignKey(d => d.IdAlimentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Caracteri__idAli__4316F928");

            entity.HasOne(d => d.TamañoData).WithMany(p => p.Caracteristicas)
                .HasForeignKey(d => d.IdTamaño)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Caracteri__idTam__440B1D61");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.IdPokemon).HasName("PK__Pokemons__653EBD858CDAE9E0");

            entity.HasIndex(e => e.Nombre, "UQ__Pokemons__75E3EFCF26A07C9A").IsUnique();

            entity.Property(e => e.IdPokemon).HasColumnName("idPokemon");
            entity.Property(e => e.DatoCurioso)
                .HasColumnType("text")
                .HasColumnName("Dato_Curioso");
            entity.Property(e => e.IdCaracteristica).HasColumnName("idCaracteristica");
            entity.Property(e => e.IdRareza).HasColumnName("idRareza");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CaracteristicaData).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.IdCaracteristica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pokemons__idCara__4BAC3F29");

            entity.HasOne(d => d.RarezaData).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.IdRareza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pokemons__idRare__48CFD27E");

            entity.HasOne(d => d.Tipo1Data).WithMany(p => p.PokemonTipo1Navigations)
                .HasForeignKey(d => d.Tipo1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pokemons__Tipo1__49C3F6B7");

            entity.HasOne(d => d.Tipo2Data).WithMany(p => p.PokemonTipo2Navigations)
                .HasForeignKey(d => d.Tipo2)
                .HasConstraintName("FK__Pokemons__Tipo2__4AB81AF0");
        });

        modelBuilder.Entity<Rareza>(entity =>
        {
            entity.HasKey(e => e.IdRareza).HasName("PK__Rarezas__27138A5C284ECF1E");

            entity.HasIndex(e => e.ContentRareza, "UQ__Rarezas__89613A2237B53D42").IsUnique();

            entity.Property(e => e.IdRareza).HasColumnName("idRareza");
            entity.Property(e => e.ContentRareza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Rareza");
        });

        modelBuilder.Entity<Tamaño>(entity =>
        {
            entity.HasKey(e => e.IdTamaño).HasName("PK__Tamaños__8288F99DCED8C8EF");

            entity.HasIndex(e => e.ContentTamaño, "UQ__Tamaños__799ED7BC6CFD92A3").IsUnique();

            entity.Property(e => e.IdTamaño).HasColumnName("idTamaño");
            entity.Property(e => e.ContentTamaño)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Tamaño");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Tipos__BDD0DFE1A9615C51");

            entity.HasIndex(e => e.Tipo1, "UQ__Tipos__8E762CB44A3AB851").IsUnique();

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Tipo1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
