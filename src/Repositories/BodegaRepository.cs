using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories
{
    public class BodegaRepository : IBodegaRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<BodegaRepository> _logger;

        public BodegaRepository(DapperContext context, ILogger<BodegaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<BodegaDto>> GetBodegasActivasAsync()
        {
            const string sql = @"
                SELECT 
                    BodegaId,
                    Descripcion
                FROM Bodegas
                WHERE TipoBodega = 1
                AND Estado = 1
            ";

            using var connection = _context.CreateConnection();

            _logger.LogInformation("Consultando bodegas activas...");

            var result = await connection.QueryAsync<BodegaDto>(sql);

            return result;
        }
    }
}