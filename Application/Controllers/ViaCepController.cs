using System.Net.Http;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Controllers
{
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ViaCepController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        [HttpGet]
        [Authorize]
        [Route("/api/v1/Endereco/{cep}")]
        public async Task<IActionResult> RecuperarEnderecoPorCep(string cep)
        {
            try
            {
                Endereco endereco = null;
                
                HttpResponseMessage response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    endereco = JsonConvert.DeserializeObject<Endereco>(responseBody);

                    return Ok(
                    new ResultViewModelCep
                    {
                        Message = "CEP Encontrado!!!",
                        Success = true,
                        Cep = endereco
                    });  // 200
                }

                else
                {
                    return BadRequest(responseBody);
                }
            }
                
            catch
            {
                return NotFound();  // 404
            }    
        }  
    }
}