using System;
using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class EstoqueCadastroViewModel
    {
        public int id { get; set; }

        [Display(Name = "Situação do produto")]
        public bool situacao { get; set; }

        [Display(Name = "Data do cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime datacad { get; set; }

        [Display(Name = "Descrição do produto")]
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
        
        [Display(Name = "Comissão(%)")]
        public Decimal comissao { get; set; }
        
        [Display(Name = "Valor de venda")]
        public Decimal valor { get; set; }
        
        [Display(Name = "Observações")]
        public string obs { get; set; }
        
        [Display(Name = "Situação tributária")]
        public int tribicmsID { get; set; }
        
        [Display(Name = "Alíq. de crédito")]
        public string aliquotacredito { get; set; }
        
        [Display(Name = "Alíq. Red. Base ICMS")]
        public string aliquotabaseicms { get; set; }
        
        [Display(Name = "Alíquota ICMS")]
        public string aliquotaicms { get; set; }
        
        [Display(Name = "Pauta fiscal")]
        public string pautafiscal { get; set; }
        
        [Display(Name = "Alíq. Red. Base ICMS ST")]
        public string aliquotabaseicmsst { get; set; }
        
        [Display(Name = "Alíq. ICMS ST")]
        public string aliquotaicmsst { get; set; }

        [Display(Name = "Situação tributária PIS")]
        public int tribpisID { get; set; }
        
        [Display(Name = "Alíquota PIS")]
        public string aliquotapis { get; set; }
        
        [Display(Name = "Situação tributária COFINS")]
        public int tribcofinsID { get; set; }
        
        [Display(Name = "Alíquota COFINS")]
        public string aliquotacofins { get; set; }

        [Display(Name = "Situação tributária IPI")]
        public int tribipiID { get; set; }
        
        [Display(Name = "Alíquota IPI")]
        public string aliquotaipi { get; set; }
        
        [Display(Name = "Alíquota ISS")]
        public string aliquotaiss { get; set; }

        public string cod { get; set; }

        public int empresaID { get; set; }
    }
}