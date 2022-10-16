using Microsoft.AspNetCore.Authorization;
using MinimalCatalogoApi.Models;
using MinimalCatalogoApi.Services;

namespace MinimalCatalogoApi.ApiEndpoints
{
    public static class AuthenticationEndpoint
    {
        //Método de extensão de WebApplication, com este método fazemos a extensao na class Program
        public static void MapAuthenticationEndpoint(this WebApplication app)
        {

            //Endpoint login
            app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenService tokenService) =>
            {
                if (userModel == null)
                {
                    return Results.BadRequest("Login nao accept");

                }
                if (userModel.UserName == "Dudu" && userModel.Password == "123")
                {
                    var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        userModel);
                    return Results.Ok(new { token = tokenString });

                }
                else
                {
                    return Results.BadRequest("Login nao accept");

                }

            }).Produces(StatusCodes.Status400BadRequest)
                        .Produces(StatusCodes.Status200OK)
                        .WithName("Login")
                        .WithTags("Autenticação");

        }

    }
}
