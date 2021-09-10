using System.Collections.Generic;
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
        private readonly ITreina_ClienteRepository _treina_ClienteRepository;
        private readonly ITreina_PropostaRepository _treina_PropostaRepository;
        public Treina_PropostaService(IMapper mapper, ITreina_ClienteRepository treina_ClienteRepository, ITreina_PropostaRepository treina_PropostaRepository)
        {
            _mapper = mapper;
            _treina_ClienteRepository = treina_ClienteRepository;
            _treina_PropostaRepository = treina_PropostaRepository;
        }
        public async Task<CompositeObjectDTO> Create(CompositeObjectDTO compositeObjectDTO)
        {
            var propostaExists = await _treina_PropostaRepository.GetByCpf(compositeObjectDTO.treina_PropostaDTO.Cpf);
            var clienteExists = await _treina_ClienteRepository.GetByCpf(compositeObjectDTO.treina_ClienteDTO.Cpf);
            
            if(clienteExists != null)
            {
                throw new DomainException("Já existe um cliente cadastrado!!!");
            }

            else if(propostaExists != null)
            {
                throw new DomainException("Já existe uma proposta cadastrada!!!");
            }
                
            else
            {
                var treina_Cliente = _mapper.Map<Treina_Cliente>(compositeObjectDTO.treina_ClienteDTO);
                
                treina_Cliente.Validate();
                //-------------------
                var treina_Proposta = _mapper.Map<Treina_Proposta>(compositeObjectDTO.treina_PropostaDTO);

                treina_Proposta.Proposta = await _treina_PropostaRepository.GerarKeyProposta();
                
                treina_Proposta.Validate();
                //-------------------
                var (treina_ClienteCreated, treina_PropostaCreated) = await _treina_PropostaRepository.Create(treina_Cliente, treina_Proposta);
                // ------------------
                
                compositeObjectDTO = new CompositeObjectDTO(_mapper.Map<Treina_ClienteDTO>(treina_ClienteCreated),_mapper.Map<Treina_PropostaDTO>(treina_PropostaCreated));

                return compositeObjectDTO;
            }
        }

        public async Task<CompositeObjectDTO> Get(string cpf)
        {
            var treina_Cliente = await _treina_ClienteRepository.GetByCpf(cpf);
            var treina_Proposta = await _treina_PropostaRepository.GetByCpf(cpf);

            var compositeObjectDTO = new CompositeObjectDTO(_mapper.Map<Treina_ClienteDTO>(treina_Cliente),_mapper.Map<Treina_PropostaDTO>(treina_Proposta));

            return compositeObjectDTO;
        }

        public async Task<List<PageListView>> GetAll(string usuario)
        {
            var arrayPageList = await _treina_PropostaRepository.GetAll(usuario);

            return arrayPageList;
        }

        public async Task<CompositeObjectDTO> Update(CompositeObjectDTO compositeObjectDTO)
        {
            var propostaExists = await _treina_PropostaRepository.GetByCpf(compositeObjectDTO.treina_PropostaDTO.Cpf);
            var clienteExists = await _treina_ClienteRepository.GetByCpf(compositeObjectDTO.treina_ClienteDTO.Cpf);
            
            if(clienteExists == null)
            {
                throw new DomainException("Não existe cliente cadastrado!!!");
            }

            else if(propostaExists == null)
            {
                throw new DomainException("Não existe  uma proposta cadastrada!!!");
            }
                
            else
            {
                var treina_Cliente = _mapper.Map<Treina_Cliente>(compositeObjectDTO.treina_ClienteDTO);
                
                treina_Cliente.Validate();
                //-------------------
                var treina_Proposta = _mapper.Map<Treina_Proposta>(compositeObjectDTO.treina_PropostaDTO);
                
                treina_Proposta.Validate();
                //--------------------
                var (treina_ClienteUpdated, treina_PropostaUpdated) = await _treina_PropostaRepository.Update(treina_Cliente, treina_Proposta);
                // ------------------
                
                compositeObjectDTO = new CompositeObjectDTO(_mapper.Map<Treina_ClienteDTO>(treina_ClienteUpdated),_mapper.Map<Treina_PropostaDTO>(treina_PropostaUpdated));

                return compositeObjectDTO;
            }
        }
    }
}