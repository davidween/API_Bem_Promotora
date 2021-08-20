using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_ClienteService
    {
        Task<Treina_ClienteDTO> Create(Treina_ClienteDTO clienteDTO);
    }
}