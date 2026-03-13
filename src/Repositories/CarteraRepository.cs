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
    public async Task<List<CarteraDto>> GetAllCartera(int numpag)
    {
        const string sql = @"
                            DECLARE @PageNumber INT = @numpag;  -- Número de página que quieres
                            DECLARE @RowsPerPage INT = 20; -- Cantidad de filas por página
                            SELECT   T1.NoIdentificacion AS nitcliente,
                                    CASE WHEN  T1.TipoDeDocumentoId = 2 THEN  DigitoDeChequeo ELSE '' END  AS dv,
                                 '' AS succliente,
	                             '' AS prefijo,
	                             T.NoDocumento AS documento ,
	                             T.FechaDocumento AS fecmov,
	                             T.FechaVencimiento AS fechavenci,
	                             T.TotalSaldo AS valor
                            FROM DBO.PersonasCuentaXCobrar T 
                            INNER JOIN DBO.Personas T1 ON ( T.PersonaId=T1.PersonaId ) 
                            WHERE T.Estado=1
                            ORDER BY T.FechaDocumento
                            OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                            FETCH NEXT @RowsPerPage ROWS ONLY;
                            ";

        using var connection = _context.CreateConnection();
        _logger .LogInformation("Consultando cartera");
        var result = (await connection.QueryAsync<CarteraDto>(sql, new { numpag = numpag })).ToList();
        return result;
    }

}
