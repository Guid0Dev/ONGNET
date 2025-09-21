using Microsoft.AspNetCore.SignalR;

namespace ONGNET.domain.dto;

public class UserDTO

{
    public UserDTO(string nome, string senha, string email, string cnpj, string cep, string numeroDoTelefone, string numeroDaResidencia, string representante, string descricao)
    {
        Nome = nome;
        Senha = senha;
        Email = email;
        CNPJ = cnpj;
        CEP = cep;
        NumeroDoTelefone = numeroDoTelefone;
        NumeroDaResidencia = numeroDaResidencia;
        Representante = representante;
        Descricao = descricao;
    }
    public string Nome { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string CNPJ { get; set; } = default!;
    public string CEP { get; set; } = default!;
    public string NumeroDoTelefone { get; set; } = default!;
    public string NumeroDaResidencia { get; set; } = default!;
    public string Representante { get; set; } = default!;

    public string Descricao { get; set; } = default!;
}
