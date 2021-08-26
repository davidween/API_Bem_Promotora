using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Treina_CalculoJuros
    {  
        [Column("Vlr_Juros", TypeName = "decimal(3,2)")]
        public decimal Vlr_Juros { get; set; }
    }
}