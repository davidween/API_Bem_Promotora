using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Treina_Usuario
    {
        [Key]
        [Column("Usuario")]
        [Required(ErrorMessage = "O usuário não pode ser vazio!!!")]
        public string Usuario { get; set; }

        [Column("Senha")]
        [Required(ErrorMessage = "A senha não pode ser vazia!!!")]
        public string Senha { get; set; }

        protected Treina_Usuario()
        {

        }

        public Treina_Usuario(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}
