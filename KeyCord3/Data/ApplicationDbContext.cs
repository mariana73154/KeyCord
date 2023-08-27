using System;
using System.Collections.Generic;
using KeyCord3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeyCord3.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admini> Adminis { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<Plataforma> Plataformas { get; set; }

    public virtual DbSet<Produtora> Produtoras { get; set; }

    public virtual DbSet<Utilizador> Utilizadors { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admini>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admini__89472E95A8F56951");

            entity.Property(e => e.IdAdmin).ValueGeneratedNever();

            entity.HasOne(d => d.IdAdminNavigation).WithOne(p => p.Admini)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admini__id_admin__2A4B4B5E");

            entity.HasOne(d => d.IdCriadorNavigation).WithMany(p => p.InverseIdCriadorNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admini__id_criad__2B3F6F97");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCat).HasName("PK__Categori__D54686DE3552D6B9");

            entity.HasMany(d => d.IdClis).WithMany(p => p.IdCats)
                .UsingEntity<Dictionary<string, object>>(
                    "Escolhe",
                    r => r.HasOne<Cliente>().WithMany()
                        .HasForeignKey("IdCli")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Escolhe__id_cli__44FF419A"),
                    l => l.HasOne<Categorium>().WithMany()
                        .HasForeignKey("IdCat")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Escolhe__id_cat__440B1D61"),
                    j =>
                    {
                        j.HasKey("IdCat", "IdCli").HasName("PK__Escolhe__B82FE74FEC24C541");
                        j.ToTable("Escolhe");
                    });
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCli).HasName("PK__Cliente__D696191744F8D799");

            entity.Property(e => e.IdCli).ValueGeneratedNever();

            entity.HasOne(d => d.IdCliNavigation).WithOne(p => p.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__id_cli__276EDEB3");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => new { e.IdJogo, e.IdCli }).HasName("PK__Compra__693014263165136C");

            entity.HasOne(d => d.IdCliNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__id_cli__412EB0B6");

            entity.HasOne(d => d.IdJogoNavigation).WithMany(p => p.Compras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compra__id_jogo__403A8C7D");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFunc).HasName("PK__Funciona__612956493743145C");

            entity.Property(e => e.IdFunc).ValueGeneratedNever();

            entity.HasOne(d => d.IdAddNavigation).WithOne(p => p.Funcionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Funcionar__id_ad__30F848ED");

            entity.HasOne(d => d.IdFuncNavigation).WithOne(p => p.Funcionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Funcionar__id_fu__300424B4");
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo).HasName("PK__Jogo__045975B7722000D7");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Jogos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jogo__id_cat__3A81B327");

            entity.HasOne(d => d.IdFuncNavigation).WithOne(p => p.Jogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jogo__id_func__3D5E1FD2");

            entity.HasOne(d => d.IdPlatNavigation).WithMany(p => p.Jogos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jogo__id_plat__3C69FB99");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.Jogos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jogo__id_prod__3B75D760");
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.IdPlat).HasName("PK__Platafor__3901EAE91B249306");
        });

        modelBuilder.Entity<Produtora>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("PK__Produtor__0DA34873EBE9D5D2");
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.IdUt).HasName("PK__Utilizad__014848A6F5E5A1D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
}
