using AppAgenda.Application.services;
using AppAgenda.Domain.Repositories;
using AppAgenda.Infraestructure.Context;
using AppAgenda.Infraestructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppAgenda.Infraestructure.Ioc;

public static class AgendaDI
{
    public static IServiceCollection RegisterDataBase(this IServiceCollection collection, IConfiguration configuration)
    {
        string connectionString = configuration["ConnectionStrings:localConnection"];

        collection.AddDbContext<AgendaDbContext>(options => { options.UseSqlServer(connectionString); }
        );
        return collection;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<UsuarioService>();
        collection.AddTransient<AgendaService>();
        collection.AddTransient<EventoService>();
        return collection;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
    {
        collection.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
        collection.AddTransient<IRepositorioAgenda, RepositorioAgenda>();
        collection.AddTransient<IRepositorioEvento, RepositorioEvento>();
        return collection;
    }

}