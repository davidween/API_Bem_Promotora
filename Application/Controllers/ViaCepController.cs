using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    class ViaCepController : ControllerBase
    {
        static HttpClient client = new HttpClient();
        
        [HttpGet]
        [Route("/Endereco/{cep}")]
        public async Task<IActionResult> RecuperarEnderecoPorCep(string cep)
        {
            try
            {
                Endereco endereco = null;
                HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/{cep}/json/");
                if (response.IsSuccessStatusCode)
                {
                    endereco = await response.Content.ReadAsAsync<Endereco>();
                }
                return Ok(endereco);  // 200
            }

            catch
            {
                return NotFound();  // 404
            }    
        }  
    }
}