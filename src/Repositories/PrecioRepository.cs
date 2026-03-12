using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class PrecioRepository : IPrecioRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<PrecioRepository> _logger;

    public PrecioRepository(DapperContext context, ILogger<PrecioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<PrecioDto>> GetAllPrecio(int numpag)
    {
        const string sql = @"
                            DECLARE @PageNumber INT = @numpag;  -- Número de página que quieres
                            DECLARE @RowsPerPage INT = 20; -- Cantidad de filas por página
                            SELECT  
	                        1 AS codlistaprecio,
                            ProductoId AS codproducto,
                            PrecioPublico1 AS valorprecio
                            FROM DBO.ProductosPrecios
                            WHERE SucursalId=1
                            ORDER BY ProductoId
                            OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                            FETCH NEXT @RowsPerPage ROWS ONLY""
";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Precios");

        var result = (await connection.QueryAsync<PrecioDto>(sql, new { numpag = numpag })).ToList();

        return result;
    }
}