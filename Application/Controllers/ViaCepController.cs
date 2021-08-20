using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Controllers
{
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        public static HttpClient client = new HttpClient();
        
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
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    endereco = JsonConvert.DeserializeObject<Endereco>(responseBody);
                }
                return Ok(
                    new ResultViewModel
                    {
                        Message = "CEP Encontrado!!!",
                        Success = true,
                        Data = endereco
                    });  // 200
            }

            catch
            {
                return NotFound();  // 404
            }    
        }  
    }
}