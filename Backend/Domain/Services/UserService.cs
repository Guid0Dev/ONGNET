using System.Text.RegularExpressions;
using Microsoft.AspNetCore.DataProtection.Repositories;
using ongnet.routes.results;
using ONGNET.domain.dto;
using ONGNET.domain.interfaces;
using ONGNET.infra.entities;
using ONGNET.infra.interfaces;

namespace ONGNET.doamin.services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<UserResult> CreateUser(UserDTO userDTO)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";

        string emailErro = "";

        if (!Regex.IsMatch(userDTO.Email, pattern))
        {
            emailErro = "Formato do e-mail inválido!";
        }

        var user = new User(
            userDTO.Nome,
            BCrypt.Net.BCrypt.HashPassword(userDTO.Senha),
            userDTO.Email,
            "User",
            userDTO.CNPJ,
            userDTO.CEP,
            userDTO.NumeroDoTelefone,
            userDTO.NumeroDaResidencia,
            userDTO.Representante,
            userDTO.Descricao
        );

        var create = await _repository.CreateUser(user);

        if (!create.Sucesso)
        {
            create.Erros.Add(emailErro);
            return create;
        }
        return new UserResult(true, null, create.User);
    }

    public async Task<UserResult> DeleteUser(Guid id)
    {
        var user = await _repository.DeleteUser(id);

        if (!user.Sucesso)
        {
            return new UserResult(false, ["Usuário não encontrado"]);
        }
        return new UserResult(true, null, null);
    }

    public async Task<UserResult> GetAllUsers(int? page)
    {
        var currentPage = page ?? 1;
        var users = await _repository.GetAllUsers(currentPage);

        return users;
    }

    public async Task<UserResult> GetUser(Guid id)
    {
        var user = await _repository.GetUser(id);
        if (!user.Sucesso)
        {
            return new UserResult(false, user.Erros);
        }
        return user;
    }

    public async Task<UserResult> Login(UserDTOLogin userDTOLogin)
    {
        
        var user = await _repository.Login(userDTOLogin);

        if (user.User == null)
        {
            user.Erros.Add("Usuário não encontrado");
        }

        if (!user.Sucesso || user.Erros != null)
        {
            return user;
        }
        
        return user;
    }

    public async Task<UserResult> UpdateUser(Guid id, UserDTO userDTO)
    {
        List<string>? errors = new();
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(userDTO.Email, pattern))
        {
            errors.Add("Formato do email inválido.");
        }

        var userToUpdate = new User(
            userDTO.Nome,
            BCrypt.Net.BCrypt.HashPassword(userDTO.Senha),
            userDTO.Email,
            "User",
            userDTO.CNPJ,
            userDTO.CEP,
            userDTO.NumeroDoTelefone,
            userDTO.NumeroDaResidencia,
            userDTO.Representante,
            userDTO.Descricao
        );
        var user = await _repository.updateUser(id, userToUpdate);

        if (!user.Sucesso)
        {
            errors.Add("userDTO.Errors[0]");
        }
        if (errors.Count > 0)
        {
            return new UserResult(false, errors);    
        }

        return new UserResult(true, null, user.User);
    }

}