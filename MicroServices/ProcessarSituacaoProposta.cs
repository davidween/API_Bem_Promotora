using System;
using System.Threading.Tasks;
using MassTransit;
using Dapper;
using Service.DataTransferObject;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace MicroServices
{
    public class ProcessarSituacaoProposta : IConsumer<FilaDTO>
    {
        private string _connection_string = "Server=localhost;Database=master;User Id=SA;Password=HaltAndCatchF1re;";
        public async Task Consume(ConsumeContext<FilaDTO> context)
        {
            var idade = CalcularIdade(context.Message.Data_Nascimento);

            var idade_prazo = CalcularIdadePrazo(idade, context.Message.Prazo);

            var situacao = await GetSituacaoAsync(idade_prazo, context.Message.Conveniada, context.Message.Vlr_Solicitado, context.Message.Proposta);
        }

        private decimal CalcularIdade(DateTime data_nascimento)
        {
            return DateTime.Now.Year - data_nascimento.Year;
        }

        public virtual async Task<List<TREINA_LIMITES_IDADE_CONVENIADA>> GetArrayRegras()
        {
            using(var conexaoBD = new SqlConnection(_connection_string))
            {
                await conexaoBD.OpenAsync();

                var query = @"SELECT CONVENIADA, IDADE_INICIAL, IDADE_FINAL, VALOR_LIMITE, PERCENTUAL_MAXIMO_ANALISE 
                              FROM TREINA_LIMITES_IDADE_CONVENIADA;";

                var array_TREINA_LIMITES_IDADE_CONVENIADA = await conexaoBD.QueryAsync<TREINA_LIMITES_IDADE_CONVENIADA>(query);

                return array_TREINA_LIMITES_IDADE_CONVENIADA.ToList();
            }
        }

        private decimal CalcularIdadePrazo(decimal idade, decimal prazo)
        {
            return Math.Floor(idade + prazo/12);
        }

        private async Task<string> GetSituacaoAsync(decimal idade_prazo, string conveniada, decimal vlr_Solicitado, decimal proposta)
        {
            var array_regras = await GetArrayRegras();

            foreach (var item in array_regras)
            {
                if(conveniada == item.Conveniada && idade_prazo >= item.Idade_Inicial && idade_prazo <= item.Idade_Final)
                {
                    if(vlr_Solicitado <= item.Valor_Limite)
                    {
                        await UpdateSituacao("AP", proposta, "");
                        return "AP";
                    }

                    else if(vlr_Solicitado <= (item.Valor_Limite + (item.Valor_Limite * item.Percentual_Maximo_Analise * (decimal)0.01)))
                    {
                        await UpdateSituacao("AN", proposta, "Proposta acima do valor limite");
                        return "AN";  // OBS.: Proposta acima do valor limite
                    }

                    else
                    {
                        await UpdateSituacao("PE", proposta, "");
                        return "PE";
                    }
                }
            }
            await UpdateSituacao("RE", proposta, "");
            return "RE";
                        // 'AG', 'AGUARDANDO AN�LISE'
                        // 'AN', 'EM AN�LISE MANUAL'
                        // 'PE', 'PENDENTE DE AVALIA��O'
                        // 'RE', 'PREPROVADA'
                        // 'AP', 'APROVADA'
        }

        private async Task<string> UpdateSituacao(string situacao, decimal proposta, string observacao) /////////////////////////////////////////////////////////
        {
            using(var conexaoBD = new SqlConnection(_connection_string))
            {
                await conexaoBD.OpenAsync();

                var atualizarBD = @"UPDATE TREINA_PROPOSTAS SET SITUACAO = @situacao, OBSERVACAO = @observacao WHERE PROPOSTA = @proposta;";

                conexaoBD.Execute(atualizarBD, new
                {
                    situacao = situacao,
                    proposta = proposta,
                    observacao = observacao
                });

                return "Atualizado com sucesso!!!";
            }
        }
    }
}