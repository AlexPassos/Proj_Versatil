using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("estoquecadastro")]
    public class EstoqueCadastro : Entity
    {
        [Key]
        public int id { get; set; }
        
        public bool situacao { get; set; }

        public DateTime? datacad { get; set; }
       
        public string descricao { get; set; }

        public int? unidadesID { get; set; }

        public int? marcasID { get; set; }

        public string ncm { get; set; }

        public int? cfopID { get; set; }

        public Decimal peso { get; set; }

        public Decimal comissao { get; set; }

        public Decimal valor { get; set; }

        public string obs { get; set; }

        public int? tribicmsID { get; set; }

        public string aliquotacredito { get; set; }

        public string aliquotabaseicms { get; set; }

        public string aliquotaicms { get; set; }

        public string pautafiscal { get; set; }

        public string aliquotabaseicmsst { get; set; }

        public string aliquotaicmsst { get; set; }

        public int? tribpisID { get; set; }

        public string aliquotapis { get; set; }

        public int? tribcofinsID { get; set; }

        public string aliquotacofins { get; set; }

        public int? tribipiID { get; set; }

        public string aliquotaipi { get; set; }

        public string aliquotaiss { get; set; }

        public string cod { get; set; }

        public int empresaID { get; set; }

        public string cest { get; set; }

        public virtual Unidades Unidades { get; set; }
        public virtual Marcas Marcas { get; set; }
        public virtual Cfop Cfop { get; set; }
        public virtual Empresas Empresa { get; set; }
        public virtual SituacaoTributaria Tribicms { get; set; }
        public virtual SituacaoTributariaCofins Tribcofins { get; set; }
        public virtual SituacaoTributariaIpi Tribipi { get; set; }
        public virtual SituacaoTributariaPis Tribpis { get; set; }

    }
}