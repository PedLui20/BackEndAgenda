namespace AppAgenda.Domain.dto;

public record EventoDto(
    int Id,
    string Nombre,
    string Descripcion,
    DateTime Fecha,
    string Lugar,
    int CantidadParticipantes
    );