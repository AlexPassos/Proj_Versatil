using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class BancosViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome do banco")]
        public string descricao { get; set; }

        public int empresaID { get; set; }
    }
}