using dotnetapi.domain.requests;
using Microsoft.AspNetCore.Mvc;
using ONGNET;
using ONGNET.domain.dto;
using ONGNET.domain.interfaces;

namespace ongnet.routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app)
    {
        var route = app.MapGroup("/api/users");

        route.MapGet("/", async ([FromQuery] int? page, IUserService userService) =>
        {
            var users = await userService.GetAllUsers(page);
            return Results.Ok(new { users = users.User });
        }).WithTags("Users");

        route.MapGet("/user", async ([FromQuery] string id, IUserService userService) =>
        {
            var user = await userService.GetUser(Guid.Parse(id));

            if (user == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(new { user.User });
        }).WithTags("Users");

        route.MapPost("/login", async ([FromBody] UserRequestLogin userRequestLogin, IUserService userService) =>
        {
            var userLogin = new UserDTOLogin(
                userRequestLogin.Email,
                userRequestLogin.Senha
             );

            var login = await userService.Login(userLogin);
            if (login == null)
            {
                return Results.BadRequest(new{errors = "Usuário ou senha incorretos"});
            }

            return Results.Ok(new{user = login});
        }).WithTags("Users");

        route.MapPost("/create", async ([FromBody] UserRequestCreate userRequestCreate, IUserService userservice) =>
        {
            var user = new UserDTO(
                userRequestCreate.Nome,
                userRequestCreate.Senha,
                userRequestCreate.Email,
                userRequestCreate.CNPJ,
                userRequestCreate.CEP,
                userRequestCreate.NumeroDoTelefone,
                userRequestCreate.NumeroDaResidencia,
                userRequestCreate.Representante,
                userRequestCreate.Descricao
            );
            var response = await userservice.CreateUser(user);

            return Results.Json(new { user = response }, statusCode: 201);
        }).WithTags("Users");
      
       route.MapPut("/{id}", async (string id, [FromBody] UserRequestCreate userRequestCreate, IUserService userService) =>
         {
             var user = new UserDTO(
                 userRequestCreate.Nome,
                 userRequestCreate.Senha,
                 userRequestCreate.Email,
                 userRequestCreate.CNPJ,
                 userRequestCreate.CEP,
                 userRequestCreate.NumeroDoTelefone,
                 userRequestCreate.NumeroDaResidencia,
                 userRequestCreate.Representante,
                 userRequestCreate.Descricao
             );

             var response = await userService.UpdateUser(Guid.Parse(id), user);

             if (!response.Sucesso)
             {
                 return Results.BadRequest(new { errors = response.Erros});
             }

             return Results.Ok(new { user = response });
         }).WithTags("Users");

        route.MapDelete("/", async ([FromQuery] string id, IUserService userService) =>
         {
             var deleted = await userService.DeleteUser(Guid.Parse(id));

             if (!deleted.Sucesso)
             {
                 return Results.BadRequest(new { errors = deleted.Erros });
             }
             return Results.Ok();
         }).WithTags("Users");

    }
}