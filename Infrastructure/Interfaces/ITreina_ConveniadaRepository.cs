using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_ConveniadaRepository
    {
        Task<List<Treina_Conveniada>> Get();
    }
}
