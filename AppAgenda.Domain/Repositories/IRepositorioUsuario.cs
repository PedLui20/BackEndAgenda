using AppAgenda.Domain.dto;

namespace AppAgenda.Domain.Repositories;

public interface IRepositorioUsuario: IRepositorioGenerico<UsuarioDto>
{
    Task<List<UsuarioDto>> GetAllAsync();
}