using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_UsuarioService
    {
        Task<Treina_UsuarioDTO> Get(string nome);

        Task<string> Get(string usuario, string senha);
    }
}