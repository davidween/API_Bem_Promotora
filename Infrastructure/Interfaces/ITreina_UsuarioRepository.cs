using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITreina_UsuarioRepository
    {
        Task<Treina_Usuario> GetByNome(string nome);
    }
}