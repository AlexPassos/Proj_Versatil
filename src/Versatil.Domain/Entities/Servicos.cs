using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
     [Table("servicos")]
    public class Servicos : Entity
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
         public Decimal? valor {get; set;}
        public int empresaID { get; set; }
        public virtual Empresas Empresa {get; set;}
    }
}