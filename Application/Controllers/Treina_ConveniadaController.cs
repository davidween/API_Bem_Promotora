using System;
using System.Threading.Tasks;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_ConveniadaController : ControllerBase
    {
        private readonly ITreina_ConveniadaService _treina_ConveniadaService;

        public Treina_ConveniadaController(ITreina_ConveniadaService treina_ConveniadaService)
        {
            _treina_ConveniadaService = treina_ConveniadaService;
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/treina_conveniada/get/{descricao}")]
        public async Task<IActionResult> Get(string descricao)
        {
            try
            {
                var conveniada = await _treina_ConveniadaService.Get(descricao);

                if(conveniada == null)
                    return Ok(new ResultViewModelConveniada
                    {
                        Message = "Nenhuma conveniada foi encontrado com o nome informado.",
                        Success = true,
                        Conveniada = conveniada
                    });

                return Ok(new ResultViewModelConveniada
                {
                    Message = "Conveniada encontrado com sucesso!",
                    Success = true,
                    Conveniada = conveniada
                });
            }
            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}