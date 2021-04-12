using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versatil.Domain.ViewModels
{
    public class PlanoContasViewModel
    {
        [Display(Name = "Demonstrativo de Caixa")]
        public ContasDemonstrativosViewModel Demonstrativo { get; set; }
    }
}
