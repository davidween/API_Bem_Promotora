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
        public static HttpClient client = new HttpClient();
        
        [HttpGet]
        [Authorize]
        [Route("/api/v1/Endereco/{cep}")]
        public async Task<IActionResult> RecuperarEnderecoPorCep(string cep)
        {
            try
            {
                Endereco endereco = null;
                
                HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    endereco = JsonConvert.DeserializeObject<Endereco>(responseBody);

                    return Ok(
                    new ResultViewModel
                    {
                        Message = "CEP Encontrado!!!",
                        Success = true,
                        Data1 = endereco,
                        Data2 = null
                    });  // 200
                }

                else
                {
                    return BadRequest(responseBody);  // Refatorar para meu erro !!!
                }
            }
                
            catch
            {
                return NotFound();  // 404
            }    
        }  
    }
}