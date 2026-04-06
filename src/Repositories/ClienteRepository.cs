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
                            DECLARE @RowsPerPage INT = 500; -- Cantidad de filas por página

                               SELECT 
                                NoIdentificacion AS codigo,
                                CASE WHEN  T.TipoDeDocumentoId = 2 THEN  DigitoDeChequeo ELSE '' END  AS dv,
                                '' AS sucursal,
                                NombreCompleto AS razonsocial,
                                NombreCompleto AS nombrecontacto,
                                Direccion AS direccion,
                                Telefono1 AS telefono,
                                '' AS codlistaprecio,
                                '' AS condicionpago,
                                '' AS periodicidad,
                                T1.VendedorPOSId AS codVendedor,
                                T2.CupoNeto AS cupo,
                                '' AS codigogrupodcto,
                                Email AS email,
                                '' AS tipocliente,
                                '' AS tipotercero,
                                1 AS estado
                                FROM Personas T 
                                INNER JOIN
                                DBO.Clientes T1
                                ON ( T.PersonaId= T1.PersonaId )
                                INNER JOIN
                                DBO.PersonasEmpresas T2
                                ON ( T2.PersonaId= T.PersonaId )
                                WHERE T1.Estado=1
                                ORDER BY NoIdentificacion
                                OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                FETCH NEXT @RowsPerPage ROWS ONLY";

        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando clientes");

        var result = (await connection.QueryAsync<ClienteDto>(sql, new { numpag = numpag })).ToList();
        return result;
       
}

}
