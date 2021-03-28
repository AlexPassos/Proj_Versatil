using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("cidades")]
    public class Cidades : Entity
    {
         [Key]
        public int id { get; set; }
        public string codibge { get; set; }
        public string nome { get; set; }
        public int ufID { get; set; }

        public virtual Uf Uf {get; set;}
    }
}