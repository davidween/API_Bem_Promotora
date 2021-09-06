using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITreina_SituacaoRepository
    {
        Task<string> Get(string situacao);
    }
}