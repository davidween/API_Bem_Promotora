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
        private readonly ITreina_PropostaService _treina_PropostaService;

        public Treina_PropostaController(IMapper mapper, ITreina_PropostaService treina_PropostaService)
        {
            _mapper = mapper;
            _treina_PropostaService = treina_PropostaService;
        }

        [HttpPost]
        [Route("/api/v1/treina_proposta/create")]
        public async Task<IActionResult> Create([FromBody] Treina_Proposta treina_Proposta)
        {
            try
            {
                var treina_propostaDTO = _mapper.Map<Treina_PropostaDTO>(treina_Proposta);

                var treina_PropostaCreated = await _treina_PropostaService.Create(treina_propostaDTO);

                return Ok(
                    new ResultViewModel
                    {
                        Message = "Proposta criada com sucesso!!!",
                        Success = true,
                        Data = treina_PropostaCreated
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