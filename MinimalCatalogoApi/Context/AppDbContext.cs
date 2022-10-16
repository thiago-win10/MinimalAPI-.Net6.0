﻿using Microsoft.EntityFrameworkCore;
using MinimalCatalogoApi.Models;

namespace MinimalCatalogoApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        //Fluent Validation
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Tabela Categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);
            mb.Entity<Categoria>()
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            mb.Entity<Categoria>()
                .Property(c => c.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            //Tabela Produtos
            mb.Entity<Produto>().HasKey(c => c.ProdutoId);
            mb.Entity<Produto>()
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            mb.Entity<Produto>()
                .Property(c => c.Descricao)
                .HasMaxLength(150)
                .IsRequired();

            mb.Entity<Produto>()
                .Property(c => c.Imagem)
                .HasMaxLength(100);

            mb.Entity<Produto>()
                .Property(c => c.Preco)
                .HasPrecision(14, 2)
                .IsRequired();

            //Relacionamento
            mb.Entity<Produto>()
                .HasOne<Categoria>(c => c.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(c => c.CategoriaId);


        }
    }
}
