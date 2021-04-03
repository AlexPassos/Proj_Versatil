using System;
using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class FuncionariosViewModel
    {
        [Display(Name = "Matrícula")]
        public int? id { get; set; }

        [Display(Name = "Data do cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime data { get; set; }

        [Display(Name = "Situação do funcionário")]
        public bool situacao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome completo")]
        public string nome { get; set; }

        [Display(Name = "Cargo")]
        public string cargo { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? nascimento { get; set; }

        [Display(Name = "RG")]
        public string rg { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "Carteira de trabalho")]
        public string carteira { get; set; }

        [Display(Name = "PIS")]
        public string pis { get; set; }

        [Display(Name = "Título eleitoral")]
        public string titulo { get; set; }

        [Display(Name = "Habilitação")]
        public string habilitacao { get; set; }

        [Display(Name = "Reservista")]
        public string reservista { get; set; }

        [Display(Name = "Filiação")]
        public string filiacao { get; set; }

        [Display(Name = "Data de admissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? admissao { get; set; }

        [Display(Name = "Data de demissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? demissao { get; set; }

        [Display(Name = "Salário")]
        public Decimal? salario { get; set; }

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
        public string celular { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Observações")]
        public string obs { get; set; }

        public int empresaID { get; set; }

        [Display(Name = "Nível de acesso")]
        public string nivel { get; set; }

        [Display(Name = "Login de acesso")]
        public string login { get; set; }

        [Display(Name = "Senha")]
        public string senha { get; set; }
        
        [Display(Name = "Confirmar senha")]
        public string confirmar { get; set; }

        [Display(Name = "O usuário terá acesso ao sistema?")]
        public bool acesso {get; set;}

        [Display(Name = "Data do cadastro")]
        public string strData { get {
            return data.ToString("yyyy-MM-dd");
        }}
        public string strNascimento { get {
            return nascimento?.ToString("yyyy-MM-dd");
        }}
        public string strAdmissao { get {
            return admissao?.ToString("yyyy-MM-dd");
        }}
        public string strDemissao { get {
            return demissao?.ToString("yyyy-MM-dd");
        }}
    }
}