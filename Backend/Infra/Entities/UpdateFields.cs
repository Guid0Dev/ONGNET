using System.ComponentModel.DataAnnotations;

namespace ONGNET.infra.entities;

public class UpdateFields
{
    public UpdateFields() { }
    public UpdateFields(string nome, string senha, string email, string perfil, string cnpj, string cep, string numeroDoTelefone, string numeroDaResidencia, string representante, string descricao)
    {
        Nome = nome;
        Senha = senha;
        Email = email;
        Perfil = perfil;
        CNPJ = cnpj;
        CEP = cep;
        NumeroDoTelefone = numeroDoTelefone;
        NumeroDaResidencia = numeroDaResidencia;
        Representante = representante;
        Descricao = descricao;
    }

    [Required]
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    [StringLength(255)]
    [MinLength(3)]
    public string Nome { get; protected set; } = default!;
    [Required]
    [MinLength(8)]
    public string Senha { get; protected set; } = default!;
    [Required]
    [MinLength(8)]
    [EmailAddress]
    public string Email { get; protected set; } = default!;
    [Required]
    public string Perfil { get; protected set; } = default!;
    [Required]
    public string CNPJ { get; protected set; } = default!;
    [Required]
    public string CEP { get; protected set; } = default!;
    [Required]
    [StringLength(11)]
    public string NumeroDoTelefone { get; protected set; } = default!;
    [Required]
    public string NumeroDaResidencia { get; protected set; } = default!;
    [Required]
    [StringLength(255)]
    public string Representante { get; protected set; } = default!;
    [Required]
    [StringLength(500)]
    public string Descricao { get; protected set; } = default!;
}