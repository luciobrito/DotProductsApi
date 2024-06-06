using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotProducts.Models;

[Index(nameof(Email), IsUnique = true )]
public class Usuario{
    [Key]
    public int Id {get; set;}
    public string Nome {get; set;}
    [EmailAddress]
    public string Email {get;set;}
    public string Senha {get; set;}
    public string Role = "user";
    public DateTime Timestamp {get;}

}