using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class Treina_Proposta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Proposta", TypeName = "decimal(10,0)", Order = 1)]
        public decimal Proposta { get; set; } 
        /*
        [DatabaseGenerated(DatabaseGeneratedOption.None)]: Isso significa que o EF gera o campo, pois o banco de dados não gera automaticamente.

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]: Se o próprio banco de dados gera o campo automaticamente.
        */

        [Column("Cpf")]
        public string Cpf { get; set; }

        [Column("Conveniada")]
        public string Conveniada { get; set; }

        [Column("Vlr_Solicitado", TypeName = "decimal(12,2)")]
        public decimal Vlr_Solicitado { get; set; }

        [Column("Prazo", TypeName = "decimal(3,0)")]
        public decimal Prazo { get; set; }

        [Column("Vlr_Financiado", TypeName = "decimal(12,2)")]
        public decimal Vlr_Financiado { get; set; }

        [Column("Situacao")]
        public string Situacao { get; set; }

        [Column("Observacao")]
        public string Observacao { get; set; }

        [Column("Dt_Situacao")]
        public DateTime Dt_Situacao { get; set; }

        [Column("Usuario")]
        public string Usuario { get; set; }

        [Column("Usuario_Atualizacao")]
        public string Usuario_Atualizacao { get; set; }

        [Column("Data_Atualizacao")]
        public DateTime Data_Atualizacao { get; set; }

        protected Treina_Proposta()
        {

        }

        public Treina_Proposta(string cpf, string conveniada, decimal vlr_Solicitado, decimal prazo, decimal vlr_Financiado, string situacao, string usuario)
        {
            Cpf = cpf;
            Conveniada = conveniada;
            Vlr_Solicitado = vlr_Solicitado;
            Prazo = prazo;
            Vlr_Financiado = vlr_Financiado;
            Situacao = situacao;
            Dt_Situacao = DateTime.Now;
            Usuario = usuario;
            Usuario_Atualizacao = "SISTEMA";
            Data_Atualizacao = DateTime.Now;
            _errors = new List<string>();  // inicia uma lista vazia
        }

        internal List<string> _errors;  // Toda entidade precisa de validação

        public IReadOnlyCollection<string> Errors => _errors;

        public bool Validate()
        {
            var validator = new Treina_PropostaValidator();
            var validation = validator.Validate(this);  // Estou passando o objeto Treina_Proposta

            if(validation.IsValid)
            {
                return true;
            }

            else
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Favor corrigir: ", _errors);
            }
        } 
    }
}