

using DotProducts.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Produto_Views> produto_Views {get; set;}
    public AppDbContext(DbContextOptions options): base(options){}
}