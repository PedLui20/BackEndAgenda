using AppAgenda.Domain.dto;
using AppAgenda.Domain.Repositories;
using AppAgenda.Infraestructure.Context;
using AppAgenda.Infraestructure.Database.Entities;
using AppAgenda.Infraestructure.Database.Extensions;

namespace AppAgenda.Infraestructure.Database.Repositories;

public class RepositorioUsuario : RepositorioGenerico<UsuarioEntity>, IRepositorioUsuario
{
    private readonly AgendaDbContext _dbContext;

    public RepositorioUsuario(AgendaDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<UsuarioDto> CreateAsync(UsuarioDto model)
    {
        if (model.Id == 0)
        {
            var newEntity = model.ToEntity();
            return Task.FromResult(CreateAsync(newEntity).Result.ToModel());
        }
        var entity = model.ToEntity();
        return Task.FromResult(UpdateAsync(entity).Result.ToModel());
    }

    public async Task<UsuarioDto?> GetByIdAsync(int id)
    {
        var entity = await base.GetByIdAsync(id);
        return entity?.ToModel();
    }

    public Task<List<UsuarioDto>> GetAllAsync()
    {
        return Task.FromResult(_dbContext.Usuario.Select(d => d.ToModel()).ToList());;
    }
}