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
                            DECLARE @RowsPerPage INT = 10000; -- Cantidad de filas por página

                            SELECT T.ProductoId AS codigo, 
                            DescripcionLarga AS descripcion, 
                            T2.Prefijo as codunidademp,
                            T1.Peso AS peso,
                            P.PersonaId As codProveedor,
                            P.NombreCompleto AS nomProveedor,
                            I.Valor AS iVA,
                            1 AS unidadventa,
                            T3.Descripcion AS Familia,
                            T4.Descripcion AS familia2
                            FROM productos T
                            INNER JOIN
                            DBO.Personas P
                            ON ( T.ProveedorId= P.PersonaId )
                            INNER JOIN
                            DBO.Ivas  I
                            ON ( T.IvaVentaId= I.IvaId )
                            INNER JOIN ProductosCaracteristicas T1 ON T.ProductoId = T1.ProductoId
                            INNER JOIN UnidadesDeMedida T2 ON T.UnidadDeMedidaId = T2.UnidadDeMedidaId
                            INNER JOIN Familia1 T3 ON T3.Familia1Id = T.Familia1Id
                            LEFT  JOIN Familia2 T4 ON T4.Familia2Id = T.Familia2Id
                            WHERE T.ProductoId IN ( SELECT DISTINCT  ProductoId FROM dbo.ProductosCaracteristicasSucursal WHERE Estado=1 )

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