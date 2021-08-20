using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_ClienteService : ITreina_ClienteService
    {
        private readonly IMapper _mapper;
        private readonly ITreina_ClienteRepository _treina_ClienteRepository;
        public Treina_ClienteService(IMapper mapper, ITreina_ClienteRepository treina_ClienteRepository)
        {
            _mapper = mapper;
            _treina_ClienteRepository = treina_ClienteRepository;
        }
        public async Task<Treina_ClienteDTO> Create(Treina_ClienteDTO clienteDTO)
        {
            var clienteExists = await _treina_ClienteRepository.GetByCpf(clienteDTO.Cpf);

            if(clienteExists != null)
            {
                throw new DomainException("Já existe um cliente cadastrado!!!");
            }
                
            else
            {
                var treina_Cliente = _mapper.Map<Treina_Cliente>(clienteDTO);
                
                treina_Cliente.Validate();

                var clienteCreated = await _treina_ClienteRepository.Create(treina_Cliente);

                return _mapper.Map<Treina_ClienteDTO>(clienteCreated);
            }
        }
    }
}