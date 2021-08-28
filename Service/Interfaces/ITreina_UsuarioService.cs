using System.Threading.Tasks;
using Service.DataTransferObject;

namespace Service.Interfaces
{
    public interface ITreina_UsuarioService
    {
        Task<string> Auth(Treina_UsuarioDTO treina_UsuarioDTO);
    }
}