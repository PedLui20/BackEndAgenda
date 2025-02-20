using System.Net;
using AppAgenda.Domain.dto;
using AppAgenda.Domain.Repositories;
using AppAgenda.Domain.Response;

namespace AppAgenda.Application.services;

public class UsuarioService
{
    private readonly IRepositorioUsuario _repositorioUsuario;

    public UsuarioService( IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }
    public async Task<Result<UsuarioDto>> Save(UsuarioDto dto)
    {
        var isCreated = await _repositorioUsuario.CreateAsync(dto);
        return Result<UsuarioDto>.Success(isCreated, HttpStatusCode.Created);
    }
    public async Task<Result<List<UsuarioDto>>> GetAll()
    {
        var usuarios = await _repositorioUsuario.GetAllAsync();
        return Result<List<UsuarioDto>>.Success(usuarios, HttpStatusCode.OK);
    }
    public async Task<Result<UsuarioDto?>> GetById(int identify)
    {
        var usuario =await _repositorioUsuario.GetByIdAsync(identify);
        return Result<UsuarioDto?>.Success(usuario, HttpStatusCode.OK);
    }
}