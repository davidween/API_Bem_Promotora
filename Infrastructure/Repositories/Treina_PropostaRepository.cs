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
    public class Treina_PropostaRepository : ITreina_PropostaRepository
    {
        private readonly ManagerContext _context;
        private readonly SqlConnection _connectionString;

        public Treina_PropostaRepository(ManagerContext context)
        {
            _context = context;
            _connectionString = (SqlConnection)_context.Database.GetDbConnection();
        }

        public virtual async Task<(Treina_Cliente, Treina_Proposta)> Create(Treina_Cliente treina_Cliente, Treina_Proposta treina_Proposta)
        {
            _context.Add(treina_Cliente);  // Adicionamos a entidade ao context
            _context.Add(treina_Proposta);  // Adicionamos a entidade ao context

            await _context.SaveChangesAsync();

            return (treina_Cliente, treina_Proposta);
        }

        public async Task<decimal?> GerarKeyProposta()
        {
            var obj = await _context.TREINA_PROPOSTAS
                                    .OrderByDescending(p => p.Proposta)
                                    .AsNoTracking()
                                    .ToListAsync();
            if(obj.Count <= 0)
            {
                return 1;
            }

            else
            {
                return obj.FirstOrDefault().Proposta + 1;
            } 
        }

        public async Task<Treina_Proposta> GetByCpf(string cpf)
        {
            var treina_Proposta = await _context.TREINA_PROPOSTAS
                                     .Where(x => x.Cpf == cpf)
                                     .AsNoTracking()
                                     .ToListAsync();

            return treina_Proposta.FirstOrDefault();
        }

         public virtual async Task<List<PageListView>> GetAll(string usuario)
         {
             using (_connectionString)  // Usando DAPPER
             {
                await _connectionString.OpenAsync();

                var query = @"SELECT C.CPF , C.NOME, P.PROPOSTA, CO.DESCRICAO AS DESCRICAO_CONVENIADA, P.VLR_SOLICITADO, P.PRAZO , P.VLR_FINANCIADO , S.DESCRICAO AS DESCRICAO_SITUACAO, P.OBSERVACAO , P.DT_SITUACAO , P.USUARIO
                                FROM TREINA_PROPOSTAS AS P
                                JOIN TREINA_CLIENTES AS C ON C.CPF = P.CPF 
                                JOIN TREINA_SITUACAO AS S ON P.SITUACAO = S.SITUACAO 
                                JOIN TREINA_CONVENIADAS AS CO ON P.CONVENIADA = CO.CONVENIADA 
                                WHERE P.USUARIO = @usuario;";

                var arrayPageList = await _connectionString.QueryAsync<PageListView>(query, new { usuario = usuario});

                return arrayPageList.ToList();
            }
             
            /* // Usando o Entity Framework

            var obj = await _context.TREINA_PROPOSTAS
                                    .Where(x => x.Usuario == usuario)
                                    .Join(_context.TREINA_CLIENTES, proposta => proposta.Cpf, cliente => cliente.Cpf, (proposta, cliente) => new { proposta, cliente })
                                    .Join(_context.TREINA_CONVENIADAS, proposta => proposta.proposta.Conveniada, conveniada => conveniada.Conveniada, (proposta, conveniada) => new { proposta, conveniada})
                                    .Join(_context.TREINA_SITUACAO, proposta => proposta.proposta.proposta.Situacao, situacao => situacao.Situacao, (proposta, situacao) => new { proposta, situacao})
                                    .Select(x => new { 
                                        x.proposta.proposta.cliente.Cpf,
                                        x.proposta.proposta.cliente.Nome,
                                        x.proposta.proposta.proposta.Proposta,
                                        x.proposta.conveniada.Descricao,
                                        x.proposta.proposta.proposta.Vlr_Solicitado,
                                        x.proposta.proposta.proposta.Prazo,
                                        x.proposta.proposta.proposta.Vlr_Financiado,
                                        x.situacao.DescricaoSituacao,
                                        x.proposta.proposta.proposta.Observacao,
                                        x.proposta.proposta.proposta.Dt_Situacao,
                                        x.proposta.proposta.proposta.Usuario 
                                    })
                                    .ToListAsync();        
            */
        }

        public virtual async Task<(Treina_Cliente, Treina_Proposta)> Update(Treina_Cliente treina_Cliente, Treina_Proposta treina_Proposta)
        {
            _context.Entry(treina_Cliente).State = EntityState.Modified;  // Adicionamos a entidade ao context
            _context.Entry(treina_Proposta).State = EntityState.Modified;  // Adicionamos a entidade ao context

            await _context.SaveChangesAsync();

            return (treina_Cliente, treina_Proposta);
        }
    }
}