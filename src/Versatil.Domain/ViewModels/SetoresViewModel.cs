using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class SetoresViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome do setor")]
        public string descricao { get; set; }
        public int empresaID { get; set; }
    }
}