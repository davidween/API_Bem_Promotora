using System;
using System.Threading.Tasks;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_PropostaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITreina_ClienteService _treina_ClienteService;
        private readonly ITreina_PropostaService _treina_PropostaService;

        public Treina_PropostaController(IMapper mapper, ITreina_ClienteService treina_ClienteService, ITreina_PropostaService treina_PropostaService)
        {
            _mapper = mapper;
            _treina_ClienteService = treina_ClienteService;
            _treina_PropostaService = treina_PropostaService;
        }

        [HttpPost]
        [Route("/api/v1/treina_proposta_cliente/create")]
        public async Task<IActionResult> Create([FromBody] CompositeObject compositeObject)
        {
            try
            {
                var treina_clienteDTO = _mapper.Map<Treina_ClienteDTO>(compositeObject.treina_Cliente);

                var treina_propostaDTO = _mapper.Map<Treina_PropostaDTO>(compositeObject.treina_Proposta);

                var compositeObjectDTO = new CompositeObjectDTO(treina_clienteDTO, treina_propostaDTO);

                var compositeObjectCreated = await _treina_PropostaService.Create(compositeObjectDTO);

                return Ok(
                    new ResultViewModel
                    {
                        Message = "Cliente e Proposta criados com sucesso!!!",
                        Success = true,
                        Data1 = compositeObjectCreated.treina_ClienteDTO,
                        Data2 = compositeObjectCreated.treina_PropostaDTO
                    });
            }

            catch(DomainException ex)
            {
                return StatusCode(400, Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            
            catch(Exception)  // ex para eu ver o erro exato
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}