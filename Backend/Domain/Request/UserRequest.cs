using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace ONGNET;



public class UserRequestCreate
{
    [Required]
    public string Nome { get; set; } = default!;
    [Required]
    public string Senha { get; set; } = default!;
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    public string CNPJ { get; set; } = default!;
    [Required]
    public string CEP { get; set; } = default!;
    [Required]
    public string NumeroDoTelefone { get; set; } = default!;
    [Required]
    public string NumeroDaResidencia { get; set; } = default!;
    [Required]
    public string Representante { get; set; } = default!;
    [Required]
    public string Descricao { get; set; } = default!;
}
public class UserRequestGetAll
{
    public int? Page { get; set; }
    public int? Limit {get; set;}
}