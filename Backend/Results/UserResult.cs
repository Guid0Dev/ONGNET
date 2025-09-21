using ONGNET.domain.dtto;
using ONGNET.infra.entities;

namespace ongnet.routes.results;

public class UserResult
{
    public List<string>? Erros { get; set; }
    public bool Sucesso { get; set; } = default!;
    public List<UserDTOResponse>? User { get; set; }

    public UserResult(bool sucesso, List<string>? erros, List<UserDTOResponse>? user)
    {
        Sucesso = sucesso;
        Erros = erros;
        User = user;
    }
    public UserResult(bool sucesso, List<string>? erros)
    {
        Sucesso = sucesso;
        Erros = erros;
    }
}
