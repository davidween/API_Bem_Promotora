using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class Treina_Cliente
    {
        [Key]
        [Column("Cpf")]
        public string Cpf { get; set; }  

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Dt_Nascimento")]
        public DateTime Dt_Nascimento { get; set; }

        [Column("Genero")]
        public string Genero { get; set; }
        
        [Column("Vlr_Salario", TypeName = "decimal(12,2)")]
        public decimal Vlr_Salario { get; set; }

        [Column("Logradouro")]
        public string Logradouro { get; set; }

        [Column("Numero_Residencia")]
        public string Numero_Residencia { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("Cep")]
        public string Cep { get; set; }

        [Column("Usuario_Atualizacao")]
        public string Usuario_Atualizacao { get; set; }

        [Column("Data_Atualizacao")]
        public DateTime Data_Atualizacao { get; set; }

        protected Treina_Cliente()
        {

        }

        public Treina_Cliente(string cpf, string nome, DateTime dt_Nascimento, string genero, decimal vlr_Salario, string logradouro, string numero_Residencia, string bairro, string cidade, string cep)
        {
            Cpf = cpf;
            Nome = nome;
            Dt_Nascimento = dt_Nascimento;
            Genero = genero;
            Vlr_Salario = vlr_Salario;
            Logradouro = logradouro;
            Numero_Residencia = numero_Residencia;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Usuario_Atualizacao = "SISTEMA";
            Data_Atualizacao = DateTime.Now;
            _errors = new List<string>();  // inicia uma lista vazia
        }
        
        internal List<string> _errors;  // Toda entidade precisa de validação

        public IReadOnlyCollection<string> Errors => _errors;

        public bool Validate()
        {
            var validator = new Treina_ClienteValidator();
            var validation = validator.Validate(this);  // Estou passando o objeto Treina_Cliente

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
