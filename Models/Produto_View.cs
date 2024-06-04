using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DotProducts.Models;

public class Produto_Views{
    [Key]
    public int Id {get; set;}
    public string IpAddress {get;set;}
    public int Date {get; set;}
    public int ProdutoId {get;set;}
    public Produto Produto {get; set;}
}