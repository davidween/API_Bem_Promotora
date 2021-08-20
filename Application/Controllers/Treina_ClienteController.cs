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
    public class Treina_ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITreina_ClienteService _treina_ClienteService;

        public Treina_ClienteController(IMapper mapper, ITreina_ClienteService treina_ClienteService)
        {
            _mapper = mapper;
            _treina_ClienteService = treina_ClienteService;
        }

        [HttpPost]
        [Route("/api/v1/treina_usuario/create")]
        public async Task<IActionResult> Create([FromBody] Treina_Cliente treina_Cliente)
        {
            try
            {
                var treina_clienteDTO = _mapper.Map<Treina_ClienteDTO>(treina_Cliente);

                var treina_ClienteCreated = await _treina_ClienteService.Create(treina_clienteDTO);

                return Ok(
                    new ResultViewModel
                    {
                        Message = "Cliente criado com sucesso!!!",
                        Success = true,
                        Data = treina_ClienteCreated
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