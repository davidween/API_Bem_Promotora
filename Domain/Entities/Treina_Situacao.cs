using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Treina_Situacao
    {
        [Key]
        [Column("Id_Treina_Situacao")]
        public int Id_Treina_Situacao { get; set; }

        [Column("Situacao")]
        public string Situacao { get; set; }

        [Column("Descricao")]
        public string DescricaoSituacao { get; set; }

        [Column("Usuario_Atualizacao")]
        public string Usuario_Atualizacao { get; set; }

        [Column("Data_Atualizacao")]
        public DateTime Data_Atualizacao { get; set; }
        
    }
}