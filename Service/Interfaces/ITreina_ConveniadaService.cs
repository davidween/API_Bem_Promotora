using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITreina_ConveniadaService
    {
        Task<string> Get(string descricao);
    }
}