using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("situacao_tributaria")]
    public class SituacaoTributaria : Entity
    {
        [Key]
        public int id { get; set; }
        public string sitr_pkey { get; set; }
        public string sitr_desc { get; set; }
        public string sitr_tipo { get; set; }
    }
}