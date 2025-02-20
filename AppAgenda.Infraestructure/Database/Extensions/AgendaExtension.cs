using AppAgenda.Domain.dto;
using AppAgenda.Infraestructure.Database.Entities;

namespace AppAgenda.Infraestructure.Database.Extensions;

public static class AgendaExtension
{
    public static AgendaEntity ToEntity(this AgendaDto dto)
    {
        return new AgendaEntity() {
            Id = dto.Id,
            IdEvento = dto.IdEvento,
            IdUsuario = dto.IdUsuario
        };
    }
    public static AgendaDto ToModel(this AgendaEntity entity)
    {
        return new AgendaDto (
            entity.Id, 
            entity.IdUsuario,
            entity.IdEvento
        ); 
    }
}