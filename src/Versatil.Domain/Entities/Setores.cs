using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
     [Table("setores")]
    public class Setores : Entity
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public int empresaID { get; set; }
        public virtual Empresas Empresa {get; set;}
    }
}