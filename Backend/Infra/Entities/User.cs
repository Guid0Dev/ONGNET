using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Net.Http.Headers;

namespace ONGNET.infra.entities;

public class User : UpdateFields
{
    public User() : base() { }
    public User(string nome, string senha, string email, string perfil, string cnpj, string cep, string numeroDoTelefone, string numeroDaResidencia, string representante, string descricao) : base(nome, senha, email, perfil, cnpj, cep, numeroDoTelefone, numeroDaResidencia, representante, descricao) { }

    public bool UpdateName(string nome)
    {
        Nome = nome;
        return true;
    }
    public bool UpdateSenha(string senha)
    {
        Senha = senha;
        return true;
    }
    public bool UpdateEmail(string email)
    {
        Email = email;
        return true;
    }
    public bool UpdatePerfil(string perfil)
    {
        Perfil = perfil;
        return true;
    }
    public bool UpdateCNPJ(string cnpj)
    {
        CNPJ = cnpj;
        return true;
    }
    public bool UpdateCEP(string cep)
    {
        CEP = cep;
        return true;
    }
    public bool UpdateNumeroDoTelefone(string numeroDoTelefone)
    {
        NumeroDoTelefone = numeroDoTelefone;
        return true;
    }
    public bool UpdateNumeroDaResidencia(string numeroDaResidencia)
    {
        NumeroDaResidencia = numeroDaResidencia;
        return true;
    }
    public bool UpdateRepresentante(string representante)
    {
        Representante = representante;
        return true;
    }
    public bool UpdateDescricao(string descricao)
    {
        Descricao = descricao;
        return true;
    }
    
}