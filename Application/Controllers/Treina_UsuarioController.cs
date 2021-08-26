using System;
using System.Threading.Tasks;
using Application.Token;
using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITreina_UsuarioService _treina_UsuarioService;
        private IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public Treina_UsuarioController(IMapper mapper, ITreina_UsuarioService treina_UsuarioService, IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _treina_UsuarioService = treina_UsuarioService;
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        /*[HttpGet]
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
                        Data1 = treina_Usuario,
                        Data2 = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data1 = treina_Usuario,
                    Data2 = null
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
        }*/

        [HttpPost]
        [Route("/api/v1/treina_usuario/auth/")]
        public async Task<IActionResult> Login([FromBody] Treina_Usuario treina_Usuario)
        {
            try
            {
                var treina_UsuarioDTO = _mapper.Map<Treina_UsuarioDTO>(treina_Usuario);

                var usuarioMessage = await _treina_UsuarioService.Auth(treina_UsuarioDTO);

                _configuration["Jwt:Login"] = treina_UsuarioDTO.Usuario;
                _configuration["Jwt:Password"] = treina_UsuarioDTO.Senha;

                if(usuarioMessage == "Logado!!!")
                {
                    return Ok(new ResultViewModel
                    {
                        Message = usuarioMessage,
                        Success = true,
                        Data1 = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                        // Continua mostrando o Data2 *************************************************************
                    });
                }

                else
                {
                    return StatusCode(401, usuarioMessage);
                }
            }
            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}