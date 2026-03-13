using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class VendedorRepository : IVendedorRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<VendedorRepository> _logger;
    public VendedorRepository(DapperContext context, ILogger<VendedorRepository> logger)

    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<VendedorDto>> GetAllVendedor(int numpag)
    {
        const string sql = @"
        DECLARE @PageNumber INT = @numpag; 
        DECLARE @RowsPerPage INT = 20; 

        SELECT
            1 AS numerocompania,
            T1.PersonaId AS codvendedor,
            '' AS centrooperacion,
            T1.Codigo AS prefijo,
            T.NombreCompleto AS descripcion,
            '' AS centrocostos,
            '' AS Clasificación
        FROM dbo.Personas T
        INNER JOIN dbo.Vendedores T1 ON T.PersonaId = T1.PersonaId
        ORDER BY T1.PersonaId
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Vendedors");

        var result = (await connection.QueryAsync<VendedorDto>(sql, new { numpag = numpag })).ToList();

        return result;
    }
}