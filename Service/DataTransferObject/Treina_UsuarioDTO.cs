using System;

namespace Service.DataTransferObject
{
    public class Treina_UsuarioDTO
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        /*public string Nome { get; set; }

        public string Usuario_Atualizacao { get; set; }

        public DateTime Data_Atualizacao { get; set; }

        public DateTime Senha_Validade { get; set; }*/

        public Treina_UsuarioDTO()
        {

        }

        public Treina_UsuarioDTO(string usuario, string senha/*, string nome, string usuario_Atualizacao, DateTime data_Atualizacao, DateTime senha_Validade*/)
        {
            Usuario = usuario;
            Senha = senha;
            /*Nome = nome;
            Usuario_Atualizacao = usuario_Atualizacao;
            Data_Atualizacao = data_Atualizacao;
            Senha_Validade = senha_Validade;*/
        }
    }
}