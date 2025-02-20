using AppAgenda.Domain.dto;

namespace AppAgenda.Domain.Repositories;

public interface IRepositorioAgenda: IRepositorioGenerico<AgendaDto>
{
    Task<AgendaDto> SaveAgendaAsync(int userId, int eventId);
}