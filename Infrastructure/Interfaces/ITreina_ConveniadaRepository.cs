using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITreina_ConveniadaRepository
    {
        Task<string> GetByDescricao(string descricao);
    }
}
