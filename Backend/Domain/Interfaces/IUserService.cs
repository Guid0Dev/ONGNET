using ongnet.routes.results;
using ONGNET.domain.dto;
using ONGNET.infra.entities;

namespace ONGNET.domain.interfaces;

public interface IUserService
{
    Task<UserResult> GetAllUsers(int? page); 
    Task<UserResult> GetUser(Guid id); // pega o usúario.
    Task<UserResult> CreateUser(UserDTO userDTO); // cria o usúario.
    Task<UserResult> Login(UserDTOLogin userDTOLogin);
    Task<UserResult> UpdateUser(Guid id,UserDTO userDTO); // atualiza o usúario
    Task<UserResult> DeleteUser(Guid id); // deleta o usúario.
}