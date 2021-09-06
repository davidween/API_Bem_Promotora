using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface ITreina_ConveniadaService
    {
        Task<List<Treina_Conveniada>> Get();
    }
}