using System.Net;
using AppAgenda.Domain.dto;
using AppAgenda.Domain.Repositories;
using AppAgenda.Domain.Response;

namespace AppAgenda.Application.services;

public class EventoService
{
    private readonly IRepositorioEvento _repositorioEvento;
    private readonly IRepositorioAgenda _repositorioAgenda;

    public EventoService( IRepositorioEvento repositorioEvento, IRepositorioAgenda repositorioAgenda)
    {
        _repositorioEvento = repositorioEvento;
        _repositorioAgenda = repositorioAgenda;
    }
    public async Task<Result<EventoDto>> Save(EventoDto dto, int userId)
    {
        var isCreated = await _repositorioEvento.CreateAsync(dto);
        var eventId = isCreated.Id;
        
        var agendaCreated = await _repositorioAgenda.SaveAgendaAsync(userId, eventId);
        
        return Result<EventoDto>.Success(isCreated, HttpStatusCode.Created);
    }
    public async Task<Result<List<EventoDto>>> GetAll(int userId)
    {
        var usuarios = await _repositorioEvento.GetAllAsync(userId);
        return Result<List<EventoDto>>.Success(usuarios, HttpStatusCode.OK);
    }
    public async Task<Result<EventoDto?>> GetById(int identify)
    {
        var usuario =await _repositorioEvento.GetByIdAsync(identify);
        return Result<EventoDto?>.Success(usuario, HttpStatusCode.OK);
    }
}