using MassTransit;

using System;
using System.Threading.Tasks;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Service.Services
{
    public class FilaService : IFilaService
    {
        private IBusControl _busControl;

        public FilaService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task Enviar(decimal proposta, DateTime data_nascimento, decimal prazo, string conveniada, decimal vlr_solicitado)
        {
            await _busControl.Publish(new FilaDTO
            {
                Proposta = proposta,
                Data_Nascimento = data_nascimento,
                Prazo = prazo,
                Conveniada = conveniada,
                Vlr_Solicitado = vlr_solicitado
            });
        }
    }
}