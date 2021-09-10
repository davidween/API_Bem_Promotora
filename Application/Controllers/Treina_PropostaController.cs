using System;
using System.Threading.Tasks;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IFilaService _filaService;

        public Treina_PropostaController(IMapper mapper, ITreina_PropostaService treina_PropostaService, IFilaService filaService)
        {
            _mapper = mapper;
            _treina_PropostaService = treina_PropostaService;
            _filaService = filaService;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/treina_cliente_proposta/create")]
        public async Task<IActionResult> Create([FromBody] CompositeObjectDTO compositeObjectDTO)
        {
            try
            {
                var compositeObjectCreated = await _treina_PropostaService.Create(compositeObjectDTO);

                await _filaService.Enviar(compositeObjectCreated.treina_PropostaDTO.Proposta, 
                                          compositeObjectCreated.treina_ClienteDTO.Dt_Nascimento, 
                                          compositeObjectCreated.treina_PropostaDTO.Prazo, 
                                          compositeObjectCreated.treina_PropostaDTO.Conveniada, 
                                          compositeObjectCreated.treina_PropostaDTO.Vlr_Financiado);
            
                return Ok(
                    new ResultViewModel
                    {
                        Message = "Cliente e Proposta criados com sucesso!!!",
                        Success = true,
                        Data1 = compositeObjectCreated.treina_ClienteDTO,
                        Data2 = compositeObjectCreated.treina_PropostaDTO
                    });
            }

            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }

            catch(Exception e) 
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/treina_cliente_proposta/get/{cpf}")]
        public async Task<IActionResult> Get(string cpf)
        {
            try
            {
                var compositeObjectDTO = await _treina_PropostaService.Get(cpf);

                return Ok(new ResultViewModel
                {
                    Message = "Consulta realizada com sucesso!",
                    Success = true,
                    Data1 = compositeObjectDTO.treina_ClienteDTO,
                    Data2 = compositeObjectDTO.treina_PropostaDTO
                });
            }

            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }

            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/treina_cliente_proposta/getall/{usuario}")]
        public async Task<IActionResult> GetAll(string usuario)
        {
            try
            {
                var arrayPageList = await _treina_PropostaService.GetAll(usuario);

                return Ok(new ResultViewModelUnique
                {
                    Message = "Consulta realizada com sucesso!",
                    Success = true,
                    Data1 = arrayPageList
                });
            }

            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/treina_cliente_proposta/update")]
        public async Task<IActionResult> Update([FromBody] CompositeObjectDTO compositeObjectDTO)
        {
            try
            {
                var compositeObjectUpdated = await _treina_PropostaService.Update(compositeObjectDTO);

                await _filaService.Enviar(compositeObjectUpdated.treina_PropostaDTO.Proposta, 
                                          compositeObjectUpdated.treina_ClienteDTO.Dt_Nascimento, 
                                          compositeObjectUpdated.treina_PropostaDTO.Prazo, 
                                          compositeObjectUpdated.treina_PropostaDTO.Conveniada, 
                                          compositeObjectUpdated.treina_PropostaDTO.Vlr_Financiado);

                return Ok(
                    new ResultViewModel
                    {
                        Message = "Cliente e Proposta atualizados com sucesso!!!",
                        Success = true,
                        Data1 = compositeObjectUpdated.treina_ClienteDTO,
                        Data2 = compositeObjectUpdated.treina_PropostaDTO
                    });
            }

            catch (DomainException e)
            {
                return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
            }

            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}