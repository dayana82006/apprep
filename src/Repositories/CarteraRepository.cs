using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class CarteraRepository : ICarteraRepository
{
    public readonly DapperContext _context;
    public readonly ILogger _logger;

    public CarteraRepository(DapperContext context, ILogger<CarteraRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<CarteraDto>> GetAllCartera()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();
        _logger .LogInformation("Consultando cartera");
        var result = (await connection.QueryFirst<CarteraDto>(sql)).ToList();
        return result
    }

    public async Task<List<string>>GetCarteraPipe(string id)
    {
        var cartera = await GetAllCartera();
        return cartera.Select(a =>
         $"{a.NitCliente}|{a.Div}|{a.SucCliente}|{a.Prefijo}|{a.Documento}|{a.FecMov}|{a.Fechavenci}|{a.Valor}"
        ).ToList();
    }

}
