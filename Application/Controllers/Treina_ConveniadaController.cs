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
        [Route("/api/v1/treina_conveniada/get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var conveniadas = await _treina_ConveniadaService.Get();

                if(conveniadas == null)
                    return Ok(new ResultViewModelConveniada
                    {
                        Message = "Nenhuma conveniada foi encontrado com o nome informado.",
                        Success = true,
                        Conveniada = conveniadas
                    });

                return Ok(new ResultViewModelConveniada
                {
                    Message = "Conveniadas encontradas com sucesso!",
                    Success = true,
                    Conveniada = conveniadas
                });
            }
            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}