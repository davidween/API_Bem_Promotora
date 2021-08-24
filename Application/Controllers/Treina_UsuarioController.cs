using System;
using System.Threading.Tasks;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITreina_UsuarioService _treina_UsuarioService;

        public Treina_UsuarioController(IMapper mapper, ITreina_UsuarioService treina_UsuarioService)
        {
            _mapper = mapper;
            _treina_UsuarioService = treina_UsuarioService;
        }

        [HttpGet]
        [Route("/api/v1/treina_usuario/get/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var treina_Usuario = await _treina_UsuarioService.Get(nome);

                if(treina_Usuario == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o nome informado.",
                        Success = true,
                        Data = treina_Usuario
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = treina_Usuario
                });
            }

            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/treina_usuario/auth/get/")]
        public async Task<IActionResult> Get([FromQuery] string usuario, [FromQuery] string senha)
        {
            try
            {
                var resposta = await _treina_UsuarioService.Get(usuario, senha);

                return Ok(new ResultViewModel
                {
                    Message = "Resposta encontrado com sucesso!",
                    Success = true,
                    Data = resposta
                });
            }
            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}