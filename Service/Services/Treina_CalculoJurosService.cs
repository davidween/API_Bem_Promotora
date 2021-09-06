using System;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_CalculoJurosService : ITreina_CalculoJurosService
    {
        private readonly ITreina_CalculoJurosRepository _treina_CalculoJurosRepository;

        public Treina_CalculoJurosService()
        {
        }

        public Treina_CalculoJurosService(ITreina_CalculoJurosRepository treina_CalculoJurosRepository)
        {
            _treina_CalculoJurosRepository = treina_CalculoJurosRepository;
        }

        public async Task<decimal> Get(decimal Vlr_Solicitado, decimal Prazo)
        {
            var Vlr_Juros = await _treina_CalculoJurosRepository.Get(Vlr_Solicitado, Prazo);

            var Vlr_Financiado = (double)Vlr_Solicitado * Math.Pow((double)(1 + Vlr_Juros), (double)Prazo);

            /*    
            A = P * (1 + i) ^ t

            Para entender melhor a formula segue a explicação de cada variável:

                A = Valor final ou seja o resultado que você terá;
                P = Valor inicial que depositado;
                i = Taxa de juros;
                t = É o tempo do investimento.
            */
            
            return (decimal)Math.Round(Vlr_Financiado, 2);
        }
    }
}