using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class ProductoRepository : IProductoRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<ProductoRepository> _logger;

    public ProductoRepository(DapperContext context, ILogger<ProductoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<ProductoDto>> GetAllProducto(int numpag)
    {
        const string sql = @"
                            DECLARE @PageNumber INT = @numpag;  -- Número de página que quieres
                            DECLARE @RowsPerPage INT = 20; -- Cantidad de filas por página

                            SELECT 
                                T.ProductoId AS codigo, 
                                DescripcionLarga AS descripcion, 
                                T2.Prefijo AS codunidademp,
                                T1.Peso AS peso,
                                T.IvaVentaId AS IVA,
                                1 AS UnidadVenta,
                                T3.Descripcion AS Segmento,
                                T4.Descripcion AS FamiliaDeProducto
                            FROM productos T
                            INNER JOIN ProductosCaracteristicas T1 ON T.ProductoId = T1.ProductoId
                            INNER JOIN UnidadesDeMedida T2 ON T.UnidadDeMedidaId = T2.UnidadDeMedidaId
                            INNER JOIN Familia1 T3 ON T3.Familia1Id = T.Familia1Id
                            INNER JOIN Familia2 T4 ON T4.Familia2Id = T.Familia2Id
                            ORDER BY T.ProductoId
                            OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                            FETCH NEXT @RowsPerPage ROWS ONLY;
                            ";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Productos");

        var result = (await connection.QueryAsync<ProductoDto>(sql, new{ numpag = numpag })).ToList();

        return result;
    }
}