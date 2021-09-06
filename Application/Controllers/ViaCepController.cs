using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service.Interfaces;
using Service.Services;

namespace Application.Controllers
{
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        private readonly IViaCepService _viaCepService;

        public ViaCepController(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }
        
        [HttpGet]
        [Authorize]
        [Route("/api/v1/Endereco/{cep}")]
        public async Task<IActionResult> RecuperarEnderecoPorCep(string cep)
        {
            try
            {
                var endereco = await _viaCepService.RecuperarEnderecoPorCep(cep);

                return Ok(
                    new ResultViewModelCep
                    {
                        Message = "CEP Encontrado!!!",
                        Success = true,
                        Cep = endereco
                    });  // 200
            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
        }  
    }
}