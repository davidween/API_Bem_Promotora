using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITreina_CalculoJurosRepository
    {
        Task<decimal> Get(decimal Vlr_Solicitado, decimal Prazo);
    }
}