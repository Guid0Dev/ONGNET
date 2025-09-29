namespace dotnetapi.domain.requests;

public class UserRequestLogin
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
}