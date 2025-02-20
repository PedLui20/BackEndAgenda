using AppAgenda.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAgenda.Infraestructure.Context;

public class AgendaDbContext: DbContext
{
    public DbSet<UsuarioEntity> Usuario { get; set; } 
    public DbSet<AgendaEntity> Agenda { get; set; } 
    public DbSet<EventoEntity> Evento { get; set; } 
    public DbSet<ParticipanteEntity> Participante { get; set; } 
    public DbSet<EventoParticipanteEntity> EventoParticipante { get; set; } 
    
    public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options) {}
}