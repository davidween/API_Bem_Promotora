using System;
using System.Threading.Tasks;
using Application.Utilities;
using Application.ViewModels;
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
        [Route("/api/v1/treina_conveniada/get/{descricao}")]
        public async Task<IActionResult> Get(string descricao)
        {
            try
            {
                var conveniada = await _treina_ConveniadaService.Get(descricao);

                if(conveniada == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma conveniada foi encontrado com o nome informado.",
                        Success = true,
                        Data = conveniada
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Conveniada encontrado com sucesso!",
                    Success = true,
                    Data = conveniada
                });
            }
            
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}