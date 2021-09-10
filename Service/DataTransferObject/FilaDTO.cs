using System;

namespace Service.DataTransferObject
{
    public class FilaDTO
    {
        public decimal Proposta { get; set; }

        public DateTime Data_Nascimento { get; set; }

        public decimal Prazo { get; set; }

        public string Conveniada { get; set; }

        public decimal Vlr_Solicitado { get; set; }
    }
}