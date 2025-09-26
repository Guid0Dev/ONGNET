using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ongnet.infra.data;
using ongnet.routes.results;
using ONGNET.domain.dto;
using ONGNET.domain.dtto;
using ONGNET.infra.entities;
using ONGNET.infra.interfaces;

namespace ongnet.infra.repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserResult> CreateUser(User user)
    {
        var usercreated = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        if (usercreated == null)
        {
            return new UserResult(sucesso: false, erros: ["Usuário não pode ser criado"]);
        }
        return new UserResult(sucesso: true, erros: null);
    }

    public async Task<UserResult> DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return new UserResult(sucesso: false, erros: ["Usuário não encontrado"]);

        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return new UserResult(sucesso: true, erros: []);
    }

    public async Task<UserResult> GetAllUsers(int page)
    {
        var limit = 30;
        var users = _context.Users.AsQueryable()
        .AsNoTracking()
        .OrderBy(u => u.Nome)
        .Skip((page - 1) * limit)
        .Take(limit)
        .Select(u => new UserDTOResponse(
            u.Id,
            u.Nome,
            u.Email,
            u.CNPJ,
            u.CEP,
            u.NumeroDoTelefone,
            u.NumeroDaResidencia,
            u.Representante,
            u.Descricao
        ));
        
        return new UserResult(true, null, await users.ToListAsync());
    }

    public async Task<UserResult> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return new UserResult(sucesso: false, erros: ["O usuário não pode ser encontrado."]);
        }

        return new UserResult(sucesso: true, erros: [], user: [new UserDTOResponse( 
            user.Id,
            user.Nome,
            user.Email,
            user.CNPJ,
            user.CEP,
            user.NumeroDoTelefone,
            user.NumeroDaResidencia,
            user.Representante,
            user.Descricao
        )]);
    }

    public async Task<UserResult> Login(UserDTOLogin userDTOLogin)
    {
        var user = _context.Users.AsQueryable()
        .Where(u => u.Email == userDTOLogin.Email);

        var userFind = await user.FirstOrDefaultAsync();
        if (userFind == null)
        {
            return new UserResult(false, ["Email ou senha inválido"]);
        }

        if (!BCrypt.Net.BCrypt.Verify(userDTOLogin.Senha, userFind.Senha))
        {
            return new UserResult(false, ["Email ou senha inválido"]);
        }


        return new UserResult(true, null, [new UserDTOResponse(
            userFind.Id,
            userFind.Nome,
            userFind.Email,
            userFind.CNPJ,
            userFind.CEP,
            userFind.NumeroDoTelefone,
            userFind.NumeroDaResidencia,
            userFind.Representante,
            userFind.Descricao
        )]);
    }

    public async Task<UserResult> updateUser(Guid id, User user)
    {
        var searchUser = await _context.Users.FindAsync(id);

        if (searchUser == null)
        {
            return new UserResult(false, ["Id de usuário não encontrado"]);
        }

        searchUser.UpdateName(user.Nome);
        searchUser.UpdateSenha(user.Senha);
        searchUser.UpdateEmail(user.Email);
        searchUser.UpdatePerfil(user.Perfil);
        searchUser.UpdateCNPJ(user.CNPJ);
        searchUser.UpdateCEP(user.CEP);
        searchUser.UpdateNumeroDoTelefone(user.NumeroDoTelefone);
        searchUser.UpdateNumeroDaResidencia(user.NumeroDaResidencia);
        searchUser.UpdateRepresentante(user.Representante);
        searchUser.UpdateDescricao(user.Descricao);
        _context.Users.Update(searchUser);
        await _context.SaveChangesAsync();

        return new UserResult(true, null, [new UserDTOResponse( 
            user.Id,
            user.Nome,
            user.Email,
            user.CNPJ,
            user.CEP,
            user.NumeroDoTelefone,
            user.NumeroDaResidencia,
            user.Representante,
            user.Descricao
        )]);
    }
}
