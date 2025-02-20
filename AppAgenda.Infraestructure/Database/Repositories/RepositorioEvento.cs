using AppAgenda.Domain.dto;
using AppAgenda.Domain.Repositories;
using AppAgenda.Infraestructure.Context;
using AppAgenda.Infraestructure.Database.Entities;
using AppAgenda.Infraestructure.Database.Extensions;

namespace AppAgenda.Infraestructure.Database.Repositories;

public class RepositorioEvento: RepositorioGenerico<EventoEntity>, IRepositorioEvento
{
    private readonly AgendaDbContext _dbContext;

    public RepositorioEvento(AgendaDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<EventoDto> CreateAsync(EventoDto model)
    {
        if (model.Id == 0)
        {
            var newEntity = model.ToEntity();
            return Task.FromResult(CreateAsync(newEntity).Result.ToModel());
        }
        var entity = model.ToEntity();
        return Task.FromResult(UpdateAsync(entity).Result.ToModel());
    }

    public async Task<EventoDto?> GetByIdAsync(int id)
    {
        var entity = await base.GetByIdAsync(id);
        return entity?.ToModel();
    }

    public Task<List<EventoDto>> GetAllAsync(int userId)
    {
        var eventos = _dbContext.Agenda
            .Where(a => a.IdUsuario == userId)
            .Select(a => a.Evento.ToModel())
            .ToList();
        
        return Task.FromResult(eventos);
    }
}