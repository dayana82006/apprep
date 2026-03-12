using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using Dapper;

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
    public async Task<List<ClienteDto>>GetAllClientes(int numpag)
    {
        const string sql = @"
                            DECLARE @PageNumber INT = @numpag;  -- Número de página que quieres
                            DECLARE @RowsPerPage INT = 20; -- Cantidad de filas por página

                                SELECT 
                                    NoIdentificacion AS codigo,
                                    DigitoDeChequeo AS dv,
                                    '' AS sucursal,
                                    RazonSocial AS razonsocial,
                                    NombreCompleto AS nombrecontacto,
                                    Direccion AS direccion,
                                    Telefono1 AS telefono,
                                    Email AS email,
                                    1 AS estado
                                FROM Personas
                                ORDER BY NoIdentificacion
                                OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                FETCH NEXT @RowsPerPage ROWS ONLY";

        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando clientes");

        var result = (await connection.QueryAsync<ClienteDto>(sql, new { numpag = numpag })).ToList();
        return result;
       
}

}
