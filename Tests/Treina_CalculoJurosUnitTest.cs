using Service.Services;
using Xunit;

namespace Tests
{
    public class Treina_CalculoJurosUnitTest
    {
        [Fact]  // O [Fact] atributo declara um método de teste que é executado pelo executor de teste. Na pasta Tests, execute dotnet test 
        public void JurosCompotosDevemRetornarCorreto()
        {
            var resultado = Treina_CalculoJurosService.CalcularJuros(1000, 10, (decimal)0.01);

            Assert.Equal((decimal)1104.62, resultado);

        }
    }
}
