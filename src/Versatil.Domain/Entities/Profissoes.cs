using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
     [Table("profissoes")]
    public class Profissoes : Entity
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
    }
}