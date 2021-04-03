using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
