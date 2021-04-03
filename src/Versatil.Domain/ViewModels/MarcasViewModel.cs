using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class MarcasViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome da marca")]
        public string descricao { get; set; }

        public int empresaID { get; set; }
    }
}