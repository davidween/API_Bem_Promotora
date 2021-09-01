using System;

namespace Domain.Entities
{
    public class PageList
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public decimal Proposta { get; set; } 

        public string Conveniada { get; set; }  // Descrição

        public decimal Vlr_Solicitado { get; set; }

        public decimal Prazo { get; set; }

        public decimal Vlr_Financiado { get; set; }

        public string Situacao { get; set; }  // Descrição

        public string Observacao { get; set; }

        public DateTime Dt_Situacao { get; set; }

        public string Usuario { get; set; }

        public PageList()
        {
            
        }

        public PageList(string cpf, string nome, decimal proposta, string conveniada, decimal vlr_Solicitado, decimal prazo, decimal vlr_Financiado, string situacao, string observacao, DateTime dt_Situacao, string usuario)
        {
            Cpf = cpf;
            Nome = nome;
            Proposta = proposta;
            Conveniada = conveniada;
            Vlr_Solicitado = vlr_Solicitado;
            Prazo = prazo;
            Vlr_Financiado = vlr_Financiado;
            Situacao = situacao;
            Observacao = observacao;
            Dt_Situacao = dt_Situacao;
            Usuario = usuario;
        }
    }
}