 using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;

namespace AplMovilBexsolucionesApi.Repositories;

public class EstadoPedidoRepository : IEstadoPedidoRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<EstadoPedidoRepository> _logger;

    public EstadoPedidoRepository(DapperContext context, ILogger<EstadoPedidoRepository> logger)
    {

        _context = context; _logger = logger;
    }
    public async Task<List<EstadoPedidoDto>>GetAll()
    {
        const string sql = @"";
        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando");
        var result = (await connection.QueryAsync<EstadoPedidoDto>(sql)).ToList();
        return result;
    }
    public async Task<List<string>> GetAllPipe()
    {
        var estado = await GetAmovil();

        return estado.Select(a =>
            $"{a.CodeEmp}|{a.CodVend}|{a.TipoPed}|{a.Numped}|{a.NumPed}|{a.NitCli}|{a.SucCli}|{a.FecPed}|{a.OrdenPed}|{a.CodPro}|{a.Refer}|{a.Descrip}|{a.CantPed}|{a.VlrBruPed}|{a.IvaBruPed}"
        ).ToList();
    }
}
