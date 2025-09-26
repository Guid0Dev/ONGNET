using ongnet.routes.results;
using ONGNET.domain.dto;
using ONGNET.infra.entities;
namespace ONGNET.infra.interfaces;

public interface IUserRepository
{
    Task<UserResult> GetAllUsers(int page); 
    Task<UserResult> GetUser(Guid id); // pega o usúario.
    Task<UserResult> CreateUser(User user); // cria o usúario.
    Task<UserResult> Login(UserDTOLogin userDTOLogin);
    Task<UserResult> updateUser(Guid id,User user); // atualiza o usúario
    Task<UserResult> DeleteUser(Guid id); // deleta o usúario.
}