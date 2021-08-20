using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_PropostaService
    {
        Task<Treina_PropostaDTO> Create(Treina_PropostaDTO propostaDTO);
    }
}