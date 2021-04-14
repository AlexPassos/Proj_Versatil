using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("cfop")]
    public class Cfop : Entity
    {
        [Key]
        public int id { get; set; }
        public string cfop { get; set; }
    }
}