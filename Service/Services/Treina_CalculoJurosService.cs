using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_CalculoJurosService : ITreina_CalculoJurosService
    {
        private readonly ITreina_CalculoJurosRepository _treina_CalculoJurosRepository;

        public Treina_CalculoJurosService(ITreina_CalculoJurosRepository treina_CalculoJurosRepository)
        {
            _treina_CalculoJurosRepository = treina_CalculoJurosRepository;
        }

        public async Task<decimal> Get(decimal Vlr_Solicitado, decimal Prazo)
        {
            var Vlr_Financiado = await _treina_CalculoJurosRepository.Get(Vlr_Solicitado, Prazo);

            return Vlr_Financiado;
        }
    }
}