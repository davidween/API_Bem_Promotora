using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Interfaces;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_UsuarioService : ITreina_UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly ITreina_UsuarioRepository _treina_UsuarioRepository;
        public Treina_UsuarioService(IMapper mapper, ITreina_UsuarioRepository treina_UsuarioRepository)
        {
            _mapper = mapper;
            _treina_UsuarioRepository = treina_UsuarioRepository;
        }
        public async Task<Treina_UsuarioDTO> Get(string nome)
        {
            var treina_Usuario = await _treina_UsuarioRepository.GetByNome(nome);

            return _mapper.Map<Treina_UsuarioDTO>(treina_Usuario);
        }

        public async Task<string> Auth(Treina_UsuarioDTO treina_UsuarioDTO)
        {
            var treina_Usuario = _mapper.Map<Treina_Usuario>(treina_UsuarioDTO);

            var message = await _treina_UsuarioRepository.Auth(treina_Usuario);

            return message;
        }
    }
}