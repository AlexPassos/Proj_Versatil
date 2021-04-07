using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versatil.Domain.Entities
{
    [Table("clientes")]
    public class Clientes : Entity
    {
        [Key]
        public int? id { get; set; }

        public DateTime datacad { get; set; }

        public int tipo { get; set; }

        public bool situacao { get; set; }

        public string nome { get; set; }

        public int sexo { get; set; }

        public DateTime? nascimento { get; set; }

        public int? civil { get; set; }

        public int? profissaoID { get; set; }

        public string fantasia { get; set; }

        public string rgie { get; set; }

        public string orgaoemissor { get; set; }

        public DateTime? dataemissao { get; set; }

        public string cpfcnpj { get; set; }

        public bool sitlimite { get; set; }
        public Decimal? limite { get; set; }

        public string endereco { get; set; }

        public string numero { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }

        public int? cidadeID { get; set; }

        public int ufID { get; set; }

        public string cep { get; set; }

        public string telefone { get; set; }

        public string celularfax { get; set; }

        public string email { get; set; }
        
        public string obs { get; set; }

        public string cod { get; set; }

        public int empresaID { get; set; }

        public virtual Cidades Cidade { get; set; }
        public virtual Uf Uf { get; set; }
        public virtual Profissoes Profissao { get; set; }
        public virtual Empresas Empresa { get; set; }
    }
}
