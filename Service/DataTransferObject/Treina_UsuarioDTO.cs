
namespace Service.DataTransferObject
{
    public class Treina_UsuarioDTO
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public Treina_UsuarioDTO()
        {

        }

        public Treina_UsuarioDTO(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}