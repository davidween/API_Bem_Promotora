using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_PropostaService
    {
        Task<CompositeObjectDTO> Create(CompositeObjectDTO compositeObjectDTO);

        Task<CompositeObjectDTO> Get(string cpf);

        Task<List<PageList>> GetAll(string usuario);

        Task<CompositeObjectDTO> Update(CompositeObjectDTO compositeObjectDTO);
    }
}