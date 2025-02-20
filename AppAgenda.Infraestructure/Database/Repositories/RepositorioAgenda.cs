using AppAgenda.Domain.dto;
using AppAgenda.Domain.Repositories;
using AppAgenda.Infraestructure.Context;
using AppAgenda.Infraestructure.Database.Entities;
using AppAgenda.Infraestructure.Database.Extensions;

namespace AppAgenda.Infraestructure.Database.Repositories;

public class RepositorioAgenda: RepositorioGenerico<AgendaEntity>, IRepositorioAgenda
{
    private readonly AgendaDbContext _dbContext;

    public RepositorioAgenda(AgendaDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<AgendaDto> CreateAsync(AgendaDto entity)
    {
        throw new NotImplementedException();
    }
    
    public async Task<AgendaDto> SaveAgendaAsync(int userId, int eventId)
    {
        var agenda = new AgendaEntity
        {
            Id = 0,
            IdUsuario = userId,
            IdEvento = eventId
        };
        
        var entityEntry = await _dbContext.Agenda.AddAsync(agenda);
        await _dbContext.SaveChangesAsync();

        var entity = entityEntry.Entity;
        return entity.ToModel();
    }

    public Task<AgendaDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}