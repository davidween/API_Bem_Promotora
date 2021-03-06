using System;
using System.Threading.Tasks;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_CalculoJurosContoller : ControllerBase
    {
        private readonly ITreina_CalculoJurosService _treina_CalculoJurosService;

        public Treina_CalculoJurosContoller(ITreina_CalculoJurosService treina_CalculoJurosService)
        {
            _treina_CalculoJurosService = treina_CalculoJurosService;
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/treina_calculo_juros/get/{Vlr_Solicitado}/{Prazo}")]
        public async Task<IActionResult> Get(decimal Vlr_Solicitado, decimal Prazo)
        {
            try
            {
                var Vlr_Financiado = await _treina_CalculoJurosService.Get(Vlr_Solicitado, Prazo);

                return Ok(new ResultViewModelJuros
                {
                    Message = "Valor Finaciado calculado com sucesso!",
                    Success = true,
                    Vlr_Financiado = Vlr_Financiado
                });
            }
            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}