using Service.Services;
using Xunit;

namespace Tests
{
    public class Treina_CalculoJurosUnitTest
    {
        [Fact]  // O [Fact] atributo declara um método de teste que é executado pelo executor de teste. Na pasta Tests, execute dotnet test 
        public async void JurosCompotosDevemRetornarCorreto()
        {
            var treina_CalculoJurosService = new Treina_CalculoJurosService();

            var resultado = await treina_CalculoJurosService.Get(1000, 10);

            Assert.Equal((decimal)1104.62, resultado);

        }
    }
}
