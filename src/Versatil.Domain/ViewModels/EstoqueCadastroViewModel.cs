using System;
using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class EstoqueCadastroViewModel
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Situação do produto")]
        public bool situacao { get; set; } = true;

        [Display(Name = "Data do cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime datacad { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Descrição do produto")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Escolha a unidade")]
        public int? unidadesID { get; set; }
        
        [Display(Name = "Escolha a marca")]
        public int? marcasID { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "NCM do produto")]
        public string ncm { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "CFOP")]
        public int? cfopID { get; set; }

        [Display(Name = "Peso do produto")]
        public Decimal peso { get; set; } = 0;

        [Display(Name = "Comissão(%)")]
        public Decimal comissao { get; set; } = 0;

        [Display(Name = "Valor de venda")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public Decimal? valor { get; set; }
        
        [Display(Name = "Observações")]
        public string obs { get; set; }
        
        [Display(Name = "Situação tributária")]
        public int? tribicmsID { get; set; }
        
        [Display(Name = "Alíq. de crédito")]
        public string aliquotacredito { get; set; } = "0";

        [Display(Name = "Alíq. Red. Base ICMS")]
        public string aliquotabaseicms { get; set; } = "0";

        [Display(Name = "Alíquota ICMS")]
        public string aliquotaicms { get; set; } = "0";

        [Display(Name = "Pauta fiscal")]
        public string pautafiscal { get; set; } = "0";

        [Display(Name = "Alíq. Red. Base ICMS ST")]
        public string aliquotabaseicmsst { get; set; } = "0";

        [Display(Name = "Alíq. ICMS ST")]
        public string aliquotaicmsst { get; set; } = "0";

        [Display(Name = "Situação tributária PIS")]
        public int? tribpisID { get; set; }
        
        [Display(Name = "Alíquota PIS")]
        public string aliquotapis { get; set; } = "0";

        [Display(Name = "Situação tributária COFINS")]
        public int? tribcofinsID { get; set; }
        
        [Display(Name = "Alíquota COFINS")]
        public string aliquotacofins { get; set; } = "0";

        [Display(Name = "Situação tributária IPI")]
        public int? tribipiID { get; set; }
        
        [Display(Name = "Alíquota IPI")]
        public string aliquotaipi { get; set; } = "0";

        [Display(Name = "Alíquota ISS")]
        public string aliquotaiss { get; set; } = "0";

        public string cod { get; set; }

        public int empresaID { get; set; }
        
        [Display(Name = "Cest")]
        public string cest { get; set; }

        [Display(Name = "Data do cadastro")]
        public string strData
        {
            get
            {
                return datacad.ToString("yyyy-MM-dd");
            }
        }
    }
}