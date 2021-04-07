using System;
using System.ComponentModel.DataAnnotations;
using Versatil.Domain.Enums;

namespace Versatil.Domain.ViewModels
{
    public class ClientesViewModel
    {
        [Display(Name = "Código")]
        public int? id { get; set; }

        [Display(Name = "Data do cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime datacad { get; set; }

        [Display(Name = "Tipo do cliente")]
        public int tipo { get; set; }

        [Display(Name = "Situação do cliente")]
        public bool situacao { get; set; } = true;

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome completo / Razão social")]
        public string nome { get; set; }

        [Display(Name = "Sexo")]
        public int sexo { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? nascimento { get; set; }

        [Display(Name = "Estado civil")]
        public int? civil { get; set; }

        [Display(Name = "Profissão")]
        public int? profissaoID { get; set; }

        [Display(Name = "Nome fantasia")]
        public string fantasia { get; set; }

        [Display(Name = "RG/IE")]
        public string rgie { get; set; }

        [Display(Name = "Orgão emissor")]
        public string orgaoemissor { get; set; }

        [Display(Name = "Data de emissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? dataemissao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "CPF/CNPJ")]
        public string cpfcnpj { get; set; }

        [Display(Name = "Cliente terá limite de compra?")]
        public bool sitlimite { get; set; } = false;

        [Display(Name = "Valor do limite")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public Decimal? limite { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Número")]
        public string numero { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Cidade")]
        public int? cidadeID { get; set; }

        [Display(Name = "UF")]
        public int ufID { get; set; }

        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "Celular")]
        public string celularfax { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Observações")]
        public string obs { get; set; }

        public string cod { get; set; }

        public int empresaID { get; set; } = 1;

        [EnumDataType(typeof(EstadoCivil))]
        public EstadoCivil EstadoCivil{get; set;}

        [Display(Name = "Data do cadastro")]
        public string strData
        {
            get
            {
                return datacad.ToString("yyyy-MM-dd");
            }
        }
        public string strNascimento
        {
            get
            {
                return nascimento?.ToString("yyyy-MM-dd");
            }
        }
        public string strEmissao
        {
            get
            {
                return dataemissao?.ToString("yyyy-MM-dd");
            }
        }
       
    }
}