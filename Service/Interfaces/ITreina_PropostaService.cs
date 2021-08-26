using System.Collections.Generic;
using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_PropostaService
    {
        Task<CompositeObjectDTO> Create(CompositeObjectDTO compositeObjectDTO);

        Task<CompositeObjectDTO> Get(string cpf);

        Task<List<CompositeObjectDTO>> GetAll(string usuario);
    }
}