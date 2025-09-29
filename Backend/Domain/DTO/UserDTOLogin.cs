namespace ONGNET.domain.dto;

public class UserDTOLogin
{
    public UserDTOLogin(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
    public string Email { get; private set; } = default!;
    public string Senha { get; private set; } = default!;
}

