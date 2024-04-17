using System.ComponentModel.DataAnnotations;

namespace DotProducts.Models;

public class Usuario{
    [Key]
    public int Id {get; set;}
    public string Nome {get; set;}
    [EmailAddress]
    public string Email {get;set;}
    public string Senha {get; set;}

}