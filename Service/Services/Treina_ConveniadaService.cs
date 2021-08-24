using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Interfaces;
using Service.DataTransferObject;
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
        public async Task<string> Get(string descricao)
        {
            var conveniada = await _treina_ConveniadaRepository.GetByDescricao(descricao);

            return conveniada;
        }
    }
}