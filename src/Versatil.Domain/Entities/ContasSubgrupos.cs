using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versatil.Domain.Entities
{

    [Table("contassubgrupo")]
    public class ContasSubgrupos: Entity
    {
        [Key]
        public int id { get; set; }

        public int contasdemonstrativosID { get; set; }
        public int contasgruposID { get; set; }

        public int codigo { get; set; }

        [Display(Name = "Nome do grupo")]
        public string nome { get; set; }

        public bool caixa { get; set; }

        public bool lucro { get; set; }

        public int empresaID { get; set; }

        public virtual ContasDemonstrativos ContasDemonstrativos { get; set; }
        public virtual ContasGrupos ContasGrupos { get; set; }
        public virtual Empresas Empresa { get; set; }
    }
}
