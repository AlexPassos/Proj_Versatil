using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class EmpresasViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Razão social")]
        public string razao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome fantasia")]
        public string fantasia { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Insc. estadual")]
        public string ie { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Cidade")]
        public int cidadeID { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "UF")]
        public int ufID { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "E-mail")]
        public string email { get; set; }
    }
}