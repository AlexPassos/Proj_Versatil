using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("uf")]
    public class Uf : Entity
    {
        [Key]
        public int id { get; set; }
        public string sigla { get; set; }
        public string estado { get; set; }

        //public virtual ICollection<Cidades> Cidades {get; set;}

    }
}