

using DotProducts.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Produto_Views> produto_Views {get; set;}
    public AppDbContext(DbContextOptions options): base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario {
                Id = 1,
                Nome = "Admin",
                Email = "admin@email.com",
                Role = "Admin",
                Senha = "$2a$12$xgKYROqH9MPTbrCgPfbQ7.i6FvZBWMKGvoRUPkAD2wipR50X3jm5q"
            }
        );
    }
}