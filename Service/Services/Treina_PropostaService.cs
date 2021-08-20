using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Service.Services
{
    public class Treina_PropostaService : ITreina_PropostaService
    {
        private readonly IMapper _mapper;
        private readonly ITreina_PropostaRepository _treina_PropostaRepository;
        public Treina_PropostaService(IMapper mapper, ITreina_PropostaRepository treina_PropostaRepository)
        {
            _mapper = mapper;
            _treina_PropostaRepository = treina_PropostaRepository;
        }
        public async Task<Treina_PropostaDTO> Create(Treina_PropostaDTO propostaDTO)
        {
            var propostaExists = await _treina_PropostaRepository.GetByCpf(propostaDTO.Cpf);

            if(propostaExists != null)
            {
                throw new DomainException("Já existe uma proposta cadastrada!!!");
            }
                
            else
            {
                var treina_Proposta = _mapper.Map<Treina_Proposta>(propostaDTO);
                
                treina_Proposta.Validate();

                var propostaCreated = await _treina_PropostaRepository.Create(treina_Proposta);

                return _mapper.Map<Treina_PropostaDTO>(propostaCreated);
            }
        }
    }
}