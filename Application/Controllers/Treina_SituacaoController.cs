using System;
using System.Threading.Tasks;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    public class Treina_SituacaoController : ControllerBase
    {
        private readonly ITreina_SituacaoService _treina_SituacaoService;

        public Treina_SituacaoController(ITreina_SituacaoService treina_SituacaoService)
        {
            _treina_SituacaoService = treina_SituacaoService;
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/treina_situacao/get/{situacao}")]
        public async Task<IActionResult> Get(string situacao)
        {
            try
            {
                var situacaoDescricao = await _treina_SituacaoService.Get(situacao);

                return Ok(new ResultViewModelSituacao
                {
                    Message = "Descrição da situação encontrada com sucesso!",
                    Success = true,
                    SituacaoDescricao = situacaoDescricao
                });
            }
            
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}