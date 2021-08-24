using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Treina_Conveniada
    {
        [Key]
        [Column("Conveniada")]
        public string Conveniada { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Usuario_Atualizacao")]
        public string Usuario_Atualizacao { get; set; }

        [Column("Data_Atualizacao")]
        public DateTime Data_Atualizacao { get; set; }
    }
}