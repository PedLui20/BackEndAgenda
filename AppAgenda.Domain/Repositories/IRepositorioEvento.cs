using AppAgenda.Domain.dto;

namespace AppAgenda.Domain.Repositories;

public interface IRepositorioEvento: IRepositorioGenerico<EventoDto>
{
    Task<List<EventoDto>> GetAllAsync(int userId);
}