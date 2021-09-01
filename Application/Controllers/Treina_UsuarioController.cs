using System;
using System.Threading.Tasks;
using Application.Token;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
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
                    return Ok(new ResultViewModelUsuario
                    {
                        Message = usuarioMessage,
                        Success = true,
                        Token = _tokenGenerator.GenerateToken(),
                        TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        
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