using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("empresas")]
    public class Empresas : Entity
    {

        [Key]
        public int id { get; set; }
        public string razao { get; set; }
        public string fantasia { get; set; }
        public string ie { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public int cidadeID { get; set; }
        public int ufID { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }

        public virtual Cidades Cidade {get; set;}
        public virtual Uf Uf {get; set;}
    }
}