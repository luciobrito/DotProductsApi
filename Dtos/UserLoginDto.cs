using System.ComponentModel.DataAnnotations;

namespace DotProducts.Dtos;

public class UserLoginDto{
    [EmailAddress]
    public string Email {get; set;}
    public string Senha {get; set;}
}