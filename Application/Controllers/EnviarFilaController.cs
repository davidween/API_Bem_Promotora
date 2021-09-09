using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnviarFilaController : ControllerBase
    {
        private IBusControl _buscontrol;

        public EnviarFilaController(IBusControl busControl)
        {
            _buscontrol = busControl;
        }
        
        [HttpPost] 
        public async Task Post(MensagemFila mensagemFila)
        {
            await _buscontrol.Publish(mensagemFila);
        }
        
    }
}