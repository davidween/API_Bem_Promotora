namespace MicroServices
{
    public class TREINA_LIMITES_IDADE_CONVENIADA
    {
        public string Conveniada { get; set; }

        public decimal Idade_Inicial { get; set; }

        public decimal Idade_Final { get; set; }

        public decimal Valor_Limite { get; set; }

        public decimal Percentual_Maximo_Analise { get; set; }

        public TREINA_LIMITES_IDADE_CONVENIADA(string conveniada, decimal idade_Inicial, decimal idade_Final, decimal valor_Limite, decimal percentual_Maximo_Analise)
        {
            Conveniada = conveniada;
            Idade_Inicial = idade_Inicial;
            Idade_Final = idade_Final;
            Valor_Limite = valor_Limite;
            Percentual_Maximo_Analise = percentual_Maximo_Analise;
        }
    }
}