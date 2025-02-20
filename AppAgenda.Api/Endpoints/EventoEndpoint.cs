using AppAgenda.Application.services;
using AppAgenda.Domain.dto;

namespace AppAgenda.Api.Endpoints;

public static class EventoEndpoint
{
    private const string BaseRoute = "/evento";
    
    internal static void MapEventoEndpoint(this WebApplication webApp)
    {
        webApp.MapGroup(BaseRoute).WithTags("EVENTOS").MapGroupEventoEndpoint();
    }

    private static void MapGroupEventoEndpoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(
            "/{userId:int}",
            (int userId,EventoDto dto, EventoService service) =>
            {
                var result = service.Save(dto, userId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        groupBuilder.MapGet(
            "/get-all/{userId:int}",
            (int userId, EventoService service) =>
            {
                var result = service.GetAll(userId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        groupBuilder.MapGet(
            "{eventoId:int}",
            (int usuarioId, EventoService service) =>
            {
                var result = service.GetById(usuarioId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
}