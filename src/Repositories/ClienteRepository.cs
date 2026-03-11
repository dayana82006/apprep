using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;

namespace AplMovilBexsolucionesApi.Repositories;

public class ClienteRepository : IClienteRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<ClienteRepository> _logger;

    public ClienteRepository(DapperContext context,  ILogger<ClienteRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<ClienteDto>>GetAllClientes()
    {
        const string sql = @"";
        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando cliente con código {codigo}", codigo);

        var cliente = await connection.QueryFirstOrDefaultAsync<ClienteDto>(sql, new { Codigo = codigo });
        return cliente;
        
    public async Task<string> GetClientesPipe()
    {
        var cliente = await GetAllClientes();
        return cliente.Select(a =>
           $"{a.Codigo}|{a.Dv}|{a.Sucursal}|{a.RazonSocial}|{a.NombreContacto}|{a.Direccion}|{a.Telefono}|{a.CodListaPrecio}|{a.CondicionPago}|{a.Periocidad}|{a.CodVendedor}|{a.Cupo}|{a.CodigoGrupoPodcto}|{a.Email}|{a.TipoCliente}|{a.TipoCliente}|{a.Estado}"
       ).ToList();
    }


}

}
