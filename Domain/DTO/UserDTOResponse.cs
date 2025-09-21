namespace ONGNET.domain.dtto;

public class UserDTOResponse
{
    public UserDTOResponse(Guid id, string nome, string email, string cnpj, string cep, string numeroDoTelefone, string numeroDaResidencia, string representante, string descricao)
    {
        Id = id;
        Nome = nome;
        Email = email;
        CNPJ = cnpj;
        CEP = cep;
        NumeroDoTelefone = numeroDoTelefone;
        NumeroDaResidencia = numeroDaResidencia;
        Representante = representante;
        Descricao = descricao;
    }
    public Guid Id { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string CNPJ { get; set; } = default!;
    public string CEP { get; set; } = default!;
    public string NumeroDoTelefone { get; set; } = default!;
    public string NumeroDaResidencia { get; set; } = default!;
    public string Representante { get; set; } = default!;
    public string Descricao { get; set; } = default!;
}
