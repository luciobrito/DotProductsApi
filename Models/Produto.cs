using System.ComponentModel.DataAnnotations;

namespace DotProducts.Models;

public class Produto{
    [Key]
    public int Id {get; set;}
    public string Nome {get; set;}
    public float Preco {get; set;}
    public string Descricao {get; set;}
}