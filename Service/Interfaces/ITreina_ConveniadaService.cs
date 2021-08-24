using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_ConveniadaService
    {
        Task<string> Get(string descricao);
    }
}