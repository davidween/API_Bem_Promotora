using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITreina_CalculoJurosService
    {
        Task<decimal> Get(decimal Vlr_Solicitado, decimal Prazo);
    }
}