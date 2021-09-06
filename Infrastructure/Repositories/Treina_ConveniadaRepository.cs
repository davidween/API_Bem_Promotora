using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Treina_ConveniadaRepository : ITreina_ConveniadaRepository
    {
        private readonly ManagerContext _context;
        private readonly SqlConnection _connectionString;

        public Treina_ConveniadaRepository(ManagerContext context)
        {
            _context = context;
            _connectionString = (SqlConnection)_context.Database.GetDbConnection();
        }
        public async Task<List<Treina_Conveniada>> Get()
        {
            using (_connectionString)  // Usando DAPPER
             {
                 await _connectionString.OpenAsync();

                var query = @"SELECT CONVENIADA, DESCRICAO, USUARIO_ATUALIZACAO, DATA_ATUALIZACAO
                            FROM TREINA_CONVENIADAS;";

                var conveniadas = await _connectionString.QueryAsync<Treina_Conveniada>(query);

                return conveniadas.ToList();
            }
        }
    }
}