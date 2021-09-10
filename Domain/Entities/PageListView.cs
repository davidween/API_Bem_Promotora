using System;

namespace Domain.Entities
{
    public class PageListView
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public decimal? Proposta { get; set; } 

        public string Descricao_Conveniada { get; set; }  // Descrição

        public decimal? Vlr_Solicitado { get; set; }

        public decimal? Prazo { get; set; }

        public decimal? Vlr_Financiado { get; set; }

        public string Descricao_Situacao { get; set; }  // Descrição

        public string Observacao { get; set; }

        public DateTime Dt_Situacao { get; set; }

        public string Usuario { get; set; }

        public PageListView()
        {
            
        }

        public PageListView(string cpf, string nome, decimal? proposta, string descricao_conveniada, decimal? vlr_Solicitado, decimal? prazo, decimal? vlr_Financiado, string descricao_situacao, string observacao, DateTime dt_Situacao, string usuario)
        {
            Cpf = cpf;
            Nome = nome;
            Proposta = proposta;
            Descricao_Conveniada = descricao_conveniada;
            Vlr_Solicitado = vlr_Solicitado;
            Prazo = prazo;
            Vlr_Financiado = vlr_Financiado;
            Descricao_Situacao = descricao_situacao;
            Observacao = observacao;
            Dt_Situacao = dt_Situacao;
            Usuario = usuario;
        }
    }
}