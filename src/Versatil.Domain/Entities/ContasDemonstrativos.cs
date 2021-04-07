using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("contasdemonstrativos")]
    public class ContasDemonstrativos : Entity
    {
        [Key]
        public int id { get; set; }
                
        public string nome { get; set; }
        
    }
}