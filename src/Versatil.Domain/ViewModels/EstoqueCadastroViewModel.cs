using System;
using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class EstoqueCadastroViewModel
    {
        [Display(Name = "C�digo")]
        public int id { get; set; }

        [Display(Name = "Situa��o do produto")]
        public bool situacao { get; set; } = true;

        [Display(Name = "Data do cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime datacad { get; set; }

        [Required(ErrorMessage = "{0} � obrigat�rio.")]
        [Display(Name = "Descri��o do produto")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "{0} � obrigat�rio.")]
        [Display(Name = "Escolha a unidade")]
        public int? unidadesID { get; set; }
        
        [Display(Name = "Escolha a marca")]
        public int? marcasID { get; set; }

        [Required(ErrorMessage = "{0} � obrigat�rio.")]
        [Display(Name = "NCM do produto")]
        public string ncm { get; set; }

        [Required(ErrorMessage = "{0} � obrigat�rio.")]
        [Display(Name = "CFOP")]
        public int? cfopID { get; set; }

        [Display(Name = "Peso do produto")]
        public Decimal peso { get; set; } = 0;

        [Display(Name = "Comiss�o(%)")]
        public Decimal comissao { get; set; } = 0;

        [Display(Name = "Valor de venda")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public Decimal? valor { get; set; }
        
        [Display(Name = "Observa��es")]
        public string obs { get; set; }
        
        [Display(Name = "Situa��o tribut�ria")]
        public int? tribicmsID { get; set; }
        
        [Display(Name = "Al�q. de cr�dito")]
        public string aliquotacredito { get; set; } = "0";

        [Display(Name = "Al�q. Red. Base ICMS")]
        public string aliquotabaseicms { get; set; } = "0";

        [Display(Name = "Al�quota ICMS")]
        public string aliquotaicms { get; set; } = "0";

        [Display(Name = "Pauta fiscal")]
        public string pautafiscal { get; set; } = "0";

        [Display(Name = "Al�q. Red. Base ICMS ST")]
        public string aliquotabaseicmsst { get; set; } = "0";

        [Display(Name = "Al�q. ICMS ST")]
        public string aliquotaicmsst { get; set; } = "0";

        [Display(Name = "Situa��o tribut�ria PIS")]
        public int? tribpisID { get; set; }
        
        [Display(Name = "Al�quota PIS")]
        public string aliquotapis { get; set; } = "0";

        [Display(Name = "Situa��o tribut�ria COFINS")]
        public int? tribcofinsID { get; set; }
        
        [Display(Name = "Al�quota COFINS")]
        public string aliquotacofins { get; set; } = "0";

        [Display(Name = "Situa��o tribut�ria IPI")]
        public int? tribipiID { get; set; }
        
        [Display(Name = "Al�quota IPI")]
        public string aliquotaipi { get; set; } = "0";

        [Display(Name = "Al�quota ISS")]
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