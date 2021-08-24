using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Treina_Usuario
    {
        [Key]
        [Column("Usuario")]
        public string Usuario { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Usuario_Atualizacao")]
        public string Usuario_Atualizacao { get; set; }

        [Column("Data_Atualizacao")]
        public DateTime Data_Atualizacao { get; set; }

        [Column("Senha_Validade")]
        public DateTime Senha_Validade { get; set; }

        protected Treina_Usuario()
        {

        }

        public Treina_Usuario(string usuario, string senha, string nome, string usuario_Atualizacao, DateTime data_Atualizacao, DateTime senha_Validade)
        {
            Usuario = usuario;
            Senha = senha;
            Nome = nome;
            Usuario_Atualizacao = usuario_Atualizacao;
            Data_Atualizacao = data_Atualizacao;
            Senha_Validade = senha_Validade;
        }
    }
}
