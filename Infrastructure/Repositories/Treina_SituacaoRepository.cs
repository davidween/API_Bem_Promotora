using System.Threading.Tasks;
using Dapper;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_SituacaoRepository : ITreina_SituacaoRepository
    {
        private readonly ManagerContext _context;
        private readonly SqlConnection _connectionString;

        public Treina_SituacaoRepository(ManagerContext context)
        {
            _context = context;
            _connectionString = (SqlConnection)_context.Database.GetDbConnection();
        }

        public async Task<string> Get(string situacao)
        {
            using (_connectionString)  // Usando DAPPER para consulta SIMPLES
            {
                await _connectionString.OpenAsync();

                var situacaoDescricao = _connectionString.QueryFirstOrDefault<string>("SELECT DESCRICAO FROM TREINA_SITUACAO WHERE SITUACAO = @situacao;", new { situacao = situacao });

                return situacaoDescricao;
            }
        }
    }
}