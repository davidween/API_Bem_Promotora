using System;

namespace Service.DataTransferObject
{
    public class Treina_PropostaDTO
    {
        public decimal Proposta { get; set; }  

        public string Cpf { get; set; }

        public string Conveniada { get; set; }

        public decimal Vlr_Solicitado { get; set; }

        public decimal Prazo { get; set; }

        public decimal Vlr_Financiado { get; set; }

        public string Situacao { get; set; }

        public string Observacao { get; set; }

        public DateTime Dt_Situacao { get; set; }

        public string Usuario { get; set; }

        public string Usuario_Atualizacao { get; set; }

        public DateTime Data_Atualizacao { get; set; }

        public Treina_PropostaDTO(){}

        public Treina_PropostaDTO(decimal proposta, string cpf, string conveniada, decimal vlr_Solicitado, decimal prazo, decimal vlr_Financiado, string situacao, string observacao, DateTime dt_Situacao, string usuario, string usuario_Atualizacao, DateTime data_Atualizacao)
        {
            Proposta = proposta;
            Cpf = cpf;
            Conveniada = conveniada;
            Vlr_Solicitado = vlr_Solicitado;
            Prazo = prazo;
            Vlr_Financiado = vlr_Financiado;
            Situacao = situacao;
            Observacao = observacao;
            Dt_Situacao = dt_Situacao;
            Usuario = usuario;
            Usuario_Atualizacao = usuario_Atualizacao;
            Data_Atualizacao = data_Atualizacao;
        }
    }
}