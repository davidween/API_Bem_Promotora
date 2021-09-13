using MicroServices;
using Xunit;

namespace Tests
{
    public class ProcessarSituacaoPropostaTest
    {
        [Fact]  // O [Fact] atributo declara um método de teste que é executado pelo executor de teste. Na pasta Tests, execute dotnet test 
        public async void RetornarSituacaoAP_INSS()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)62, "000020", (decimal)7500);

            var resultadoSituacao = "AP";

            Assert.Equal(situacao, resultadoSituacao);
        }

        [Fact]
        public async void RetornarSituacaoRE_INSS()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)83, "000020", (decimal)7500);

            var resultadoSituacao = "RE";

            Assert.Equal(situacao, resultadoSituacao);
        }

        [Fact]
        public async void RetornarSituacaoAN_INSS()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)62, "000020", (decimal)8001);

            var resultadoSituacao = "AN";

            Assert.Equal(situacao, resultadoSituacao);
        }

        [Fact]
        public async void RetornarSituacaoPE_INSS()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)62, "000020", (decimal)9000);

            var resultadoSituacao = "PE";

            Assert.Equal(situacao, resultadoSituacao);
        }

        /* ---------------------------------------------------------------------------------------------------------------------------- */


        [Fact]  // O [Fact] atributo declara um método de teste que é executado pelo executor de teste. Na pasta Tests, execute dotnet test 
        public async void RetornarSituacaoAP_SIAPE()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)44, "002399", (decimal)55000);

            var resultadoSituacao = "AP";

            Assert.Equal(situacao, resultadoSituacao);
        }

        [Fact]
        public async void RetornarSituacaoRE_SIAPE()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)80, "002399", (decimal)55000);

            var resultadoSituacao = "RE";

            Assert.Equal(situacao, resultadoSituacao);
        }

        [Fact]
        public async void RetornarSituacaoAN_SIAPE()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)44, "002399", (decimal)55001);

            var resultadoSituacao = "AN";

            Assert.Equal(situacao, resultadoSituacao);
        }

        [Fact]
        public async void RetornarSituacaoPE_SIAPE()
        {
            ProcessarSituacaoProposta processador = new ProcessarSituacaoProposta();

            var (situacao, obsevacao) = await processador.GetSituacaoAsync((decimal)44, "002399", (decimal)64901);

            var resultadoSituacao = "PE";

            Assert.Equal(situacao, resultadoSituacao);
        }
        



        // 'AG', 'AGUARDANDO AN�LISE'
        // 'AN', 'EM AN�LISE MANUAL'
        // 'PE', 'PENDENTE DE AVALIA��O'
        // 'RE', 'PREPROVADA'
        // 'AP', 'APROVADA'
    }
}