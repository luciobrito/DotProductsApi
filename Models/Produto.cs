using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DotProducts.Models;

public class Produto{
    [Key]
    public int Id {get; set;}
    public string Nome {get; set;}
    public float Preco {get; set;}
    public string Descricao {get; set;}
    public string? Image {get; set;}
    public ICollection<Produto_Views> Produto_Views {get;} = new List<Produto_Views>();
    public DateTime Timestamp {get;}
}