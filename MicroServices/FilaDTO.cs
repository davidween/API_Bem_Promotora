using System;

namespace Service.DataTransferObject  // Mesmo namespace e class name para encontrar a Fila.
{
    public class FilaDTO
    {
        public decimal Proposta { get; set; }

        public DateTime Data_Nascimento { get; set; }

        public decimal Prazo { get; set; }
    }
}