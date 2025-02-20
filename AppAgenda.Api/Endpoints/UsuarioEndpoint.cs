using AppAgenda.Application.services;
using AppAgenda.Domain.dto;

namespace AppAgenda.Api.Endpoints;

public static class UsuarioEndpoint
{
    private const string BaseRoute = "/usuario";
    
    internal static void MapUsuarioEndpoint(this WebApplication webApp)
    {
        webApp.MapGroup(BaseRoute).WithTags("USUARIOS").MapGroupUsuarioEndpoint();
    }

    private static void MapGroupUsuarioEndpoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(
            "/",
            (UsuarioDto dto, UsuarioService service) =>
            {
                var result = service.Save(dto).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        groupBuilder.MapPut(
            "{usuarioId:int}",
            (int usuarioId, UsuarioDto dto, UsuarioService service) =>
            {
                dto = dto with { Id = usuarioId };
                var result = service.Save(dto).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        groupBuilder.MapGet(
            "/",
            (UsuarioService service) =>
            {
                var result = service.GetAll().Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        groupBuilder.MapGet(
            "{usuarioId:int}",
            (int usuarioId, UsuarioService service) =>
            {
                var result = service.GetById(usuarioId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
}