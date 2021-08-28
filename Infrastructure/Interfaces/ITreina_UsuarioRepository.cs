using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_UsuarioRepository
    {
        Task<string> Auth(Treina_Usuario treina_Usuario);
    }
}