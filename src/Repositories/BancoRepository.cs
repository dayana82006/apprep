using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<BancoRepository> _logger;

        public BancoRepository(DapperContext context, ILogger<BancoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<BancoDto>> GetBanco()
        {
            const string sql = @"
               
            ";

            using var connection = _context.CreateConnection();
            _logger.LogInformation("Consultando bancos...");

            var result = (await connection.QueryAsync<BancoDto>(sql)).ToList();
            return result;
        }

        public async Task<List<string>> GetBancoPipe()
        {
            var bancos = await GetBanco();

            return bancos.Select(a =>
                $"{a.NomBanco}|{a.TipCuenta}|{a.NumCuenta}"
            ).ToList();
        }
    }
}