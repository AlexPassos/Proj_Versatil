using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("situacao_tributaria_pis")]
    public class SituacaoTributariaPis : Entity
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
    }
}