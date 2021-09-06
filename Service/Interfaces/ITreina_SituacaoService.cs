using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITreina_SituacaoService
    {
        Task<string> Get(string situacao);
    }
}