using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service.DataTransferObject;
using Service.Interfaces;

namespace Service.Services
{
    public class ViaCepService : PageModel, IViaCepService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ViaCepService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        public async Task<EnderecoDTO> RecuperarEnderecoPorCep(string cep)
        {  
            EnderecoDTO endereco = null;

            var client = _clientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://viacep.com.br/ws/{cep}/json/");

            var response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            endereco = JsonConvert.DeserializeObject<EnderecoDTO>(responseBody);

            return endereco; 
        }  
    }
}