using System;
using System.Threading;
using System.Threading.Tasks;
using core;
using MassTransit;

namespace MicroServices
{
    public class ProcessarSituacaoProposta : IConsumer<FilaDTO>
    {
        public Task Consume(ConsumeContext<FilaDTO> context)
        {
            var idade = CalcularIdade(context.Message.Data_Nascimento);

            var situacao = GetSituacao(idade, context.Message.Prazo);

            UpdateSituacao(situacao);

            return Task.CompletedTask;
        }

        private int CalcularIdade(DateTime data_nascimento)
        {}

        private string GetSituacao(int idade, decimal prazo)
        {}

        private async UpdateSituacao(string situacao)
        {
            using("Server=localhost;Database=master;User Id=SA;Password=HaltAndCatchF1re;")
            {
                
            }
        }
    }
}