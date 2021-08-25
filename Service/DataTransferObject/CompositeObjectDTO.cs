namespace Service.DataTransferObject
{
    public class CompositeObjectDTO
    {
        public CompositeObjectDTO(Treina_ClienteDTO treina_ClienteDTO, Treina_PropostaDTO treina_PropostaDTO)
        {
            this.treina_ClienteDTO = treina_ClienteDTO;
            this.treina_PropostaDTO = treina_PropostaDTO;
        }

        public Treina_ClienteDTO treina_ClienteDTO { get; set; }
        public Treina_PropostaDTO treina_PropostaDTO {get; set; }
    }
}