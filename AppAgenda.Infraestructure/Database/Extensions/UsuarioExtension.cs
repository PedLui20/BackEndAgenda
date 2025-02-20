using AppAgenda.Domain.dto;
using AppAgenda.Infraestructure.Database.Entities;

namespace AppAgenda.Infraestructure.Database.Extensions;

public static class UsuarioExtension
{
    public static UsuarioEntity ToEntity(this UsuarioDto dto)
    {
        return new UsuarioEntity() {
            Id = dto.Id,
            Nombre = dto.Nombre,
            Rol = dto.Rol
        };
    }
    public static UsuarioDto ToModel(this UsuarioEntity entity)
    {
        return new UsuarioDto (
            entity.Id, 
            entity.Nombre,
            entity.Rol
        ); 
    }
}