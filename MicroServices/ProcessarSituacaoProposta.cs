using System;
using System.Threading.Tasks;
using MassTransit;
using Dapper;
using Service.DataTransferObject;
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

            var situacao = await GetSituacaoAsync(idade_prazo, context.Message.Conveniada, context.Message.Vlr_Financiado, context.Message.Proposta);
        }

        private decimal CalcularIdade(DateTime data_nascimento)
        {
            return DateTime.Now.Year - data_nascimento.Year;
        }

        public virtual async Task<TREINA_LIMITES_IDADE_CONVENIADA> GetArrayRegras(decimal idade_prazo, string conveniada)
        {
            using(var conexaoBD = new SqlConnection(_connection_string))
            {
                await conexaoBD.OpenAsync();

                var query = @"
                                SELECT 
                                    CONVENIADA, 
                                    IDADE_INICIAL, 
                                    IDADE_FINAL, 
                                    VALOR_LIMITE, 
                                    PERCENTUAL_MAXIMO_ANALISE 
                                FROM 
                                    TREINA_LIMITES_IDADE_CONVENIADA
                                WHERE
                                    CONVENIADA = @conveniada
                                    AND @idade_prazo BETWEEN IDADE_INICIAL AND IDADE_FINAL;";

                var treina_LIMITES_IDADE_CONVENIADA = await conexaoBD.QueryAsync<TREINA_LIMITES_IDADE_CONVENIADA>(query, 
                                                                                                                  new 
                                                                                                                  { 
                                                                                                                      idade_prazo = idade_prazo, 
                                                                                                                      conveniada = conveniada
                                                                                                                  });

                return treina_LIMITES_IDADE_CONVENIADA.FirstOrDefault();
            }
        }

        private decimal CalcularIdadePrazo(decimal idade, decimal prazo)
        {
            return Math.Floor(idade + prazo/12);
        }

        private async Task<string> GetSituacaoAsync(decimal idade_prazo, string conveniada, decimal Vlr_Financiado, decimal proposta)
        {
            var regras = await GetArrayRegras(idade_prazo, conveniada);

            
            if(regras != null)
            {
                if(Vlr_Financiado <= regras.Valor_Limite)
                {
                    await UpdateSituacao("AP", proposta, "");
                    return "AP";
                }

                else if(Vlr_Financiado <= (regras.Valor_Limite + (regras.Valor_Limite * regras.Percentual_Maximo_Analise * (decimal)0.01)))
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
            
            await UpdateSituacao("RE", proposta, "");
            return "RE";
                        // 'AG', 'AGUARDANDO AN�LISE'
                        // 'AN', 'EM AN�LISE MANUAL'
                        // 'PE', 'PENDENTE DE AVALIA��O'
                        // 'RE', 'PREPROVADA'
                        // 'AP', 'APROVADA'
        }

        private async Task<string> UpdateSituacao(string situacao, decimal proposta, string observacao)
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