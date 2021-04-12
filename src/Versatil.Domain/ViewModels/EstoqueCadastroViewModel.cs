using System;
using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class EstoqueCadastroViewModel
    {
        public int id { get; set; }

        [Display(Name = "Situa��o do produto")]
        public bool situacao { get; set; }

        [Display(Name = "Data do cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime datacad { get; set; }

        [Display(Name = "Descri��o do produto")]
        public string descricao { get; set; }
        
        [Display(Name = "Escolha a unidade")]
        public int unidadesID { get; set; }
        
        [Display(Name = "Escolha a marca")]
        public int marcasID { get; set; }
        
        [Display(Name = "NCM do produto")]
        public string ncm { get; set; }
        
        [Display(Name = "CFOP")]
        public int cfopID { get; set; }
        
        [Display(Name = "Peso do produto")]
        public Decimal peso { get; set; }
        
        [Display(Name = "Comiss�o(%)")]
        public Decimal comissao { get; set; }
        
        [Display(Name = "Valor de venda")]
        public Decimal valor { get; set; }
        
        [Display(Name = "Observa��es")]
        public string obs { get; set; }
        
        [Display(Name = "Situa��o tribut�ria")]
        public int tribicmsID { get; set; }
        
        [Display(Name = "Al�q. de cr�dito")]
        public string aliquotacredito { get; set; }
        
        [Display(Name = "Al�q. Red. Base ICMS")]
        public string aliquotabaseicms { get; set; }
        
        [Display(Name = "Al�quota ICMS")]
        public string aliquotaicms { get; set; }
        
        [Display(Name = "Pauta fiscal")]
        public string pautafiscal { get; set; }
        
        [Display(Name = "Al�q. Red. Base ICMS ST")]
        public string aliquotabaseicmsst { get; set; }
        
        [Display(Name = "Al�q. ICMS ST")]
        public string aliquotaicmsst { get; set; }

        [Display(Name = "Situa��o tribut�ria PIS")]
        public int tribpisID { get; set; }
        
        [Display(Name = "Al�quota PIS")]
        public string aliquotapis { get; set; }
        
        [Display(Name = "Situa��o tribut�ria COFINS")]
        public int tribcofinsID { get; set; }
        
        [Display(Name = "Al�quota COFINS")]
        public string aliquotacofins { get; set; }

        [Display(Name = "Situa��o tribut�ria IPI")]
        public int tribipiID { get; set; }
        
        [Display(Name = "Al�quota IPI")]
        public string aliquotaipi { get; set; }
        
        [Display(Name = "Al�quota ISS")]
        public string aliquotaiss { get; set; }

        public string cod { get; set; }

        public int empresaID { get; set; }
    }
}