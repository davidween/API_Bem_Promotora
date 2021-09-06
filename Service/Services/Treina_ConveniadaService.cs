using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_ConveniadaService : ITreina_ConveniadaService
    {
        private readonly ITreina_ConveniadaRepository _treina_ConveniadaRepository;
        public Treina_ConveniadaService(ITreina_ConveniadaRepository treina_ConveniadaRepository)
        {
            _treina_ConveniadaRepository = treina_ConveniadaRepository;
        }
        public async Task<List<Treina_Conveniada>> Get()
        {
            var conveniadas = await _treina_ConveniadaRepository.Get();

            return conveniadas;
        }
    }
}