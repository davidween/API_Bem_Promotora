using System;

namespace Service.DataTransferObject
{
    public class Treina_ClienteDTO
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime Dt_Nascimento { get; set; }

        public string Genero { get; set; }

        public decimal Vlr_Salario { get; set; }

        public string Logradouro { get; set; }

        public string Numero_Residencia { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string Usuario_Atualizacao { get; set; }

        public DateTime Data_Atualizacao { get; set; }

        public Treina_ClienteDTO(){}

        public Treina_ClienteDTO(string cpf, string nome, DateTime dt_Nascimento, string genero, decimal vlr_Salario, string logradouro, string numero_Residencia, string bairro, string cidade, string cep, string usuario_Atualizacao, DateTime data_Atualizacao)
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
            Usuario_Atualizacao = usuario_Atualizacao;
            Data_Atualizacao = data_Atualizacao;
        }
    }
}