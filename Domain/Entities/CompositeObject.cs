namespace Domain.Entities
{
    public class CompositeObject
    {
        public CompositeObject(Treina_Cliente treina_Cliente, Treina_Proposta treina_Proposta)
        {
            this.treina_Cliente = treina_Cliente;
            this.treina_Proposta = treina_Proposta;
        }

        public Treina_Cliente treina_Cliente { get; set; }

        public Treina_Proposta treina_Proposta { get; set; }
    }
}