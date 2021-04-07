using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class ContasDemonstrativosViewModel
    {
        public int id { get; set; }
        
        [Display(Name = "Demonstrativo")]
        public string nome { get; set; }
        
    }
}