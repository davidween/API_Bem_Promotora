using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_SituacaoService : ITreina_SituacaoService
    {
        private readonly ITreina_SituacaoRepository _treina_SituacaoRepository;

        public Treina_SituacaoService(ITreina_SituacaoRepository treina_SituacaoRepository)
        {
            _treina_SituacaoRepository = treina_SituacaoRepository;
        }

        public async Task<string> Get(string situacao)
        {
            var situacaoDescricao = await _treina_SituacaoRepository.Get(situacao);

            return situacaoDescricao;
        }
    }
}