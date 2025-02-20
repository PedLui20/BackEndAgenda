using AppAgenda.Domain.dto;
using AppAgenda.Infraestructure.Database.Entities;

namespace AppAgenda.Infraestructure.Database.Extensions;

public static class EventoExtension
{
    public static EventoEntity ToEntity(this EventoDto dto)
    {
        return new EventoEntity {
            Id = dto.Id,
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Fecha = dto.Fecha,
            Lugar = dto.Lugar,
            CantidadParticipantes = dto.CantidadParticipantes,
        };
    }
    public static EventoDto ToModel(this EventoEntity entity)
    {
        return new EventoDto (
            entity.Id, 
            entity.Nombre,
            entity.Descripcion,
            entity.Fecha,
            entity.Lugar,
            entity.CantidadParticipantes
        ); 
    }
}