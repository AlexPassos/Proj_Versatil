using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("unidades")]
    public class Unidades : Entity
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
    }
}