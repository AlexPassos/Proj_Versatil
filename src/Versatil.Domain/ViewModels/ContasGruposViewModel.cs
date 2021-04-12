using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class ContasGruposViewModel
    {
        public int id { get; set; }

        public int contasdemonstrativosID { get; set; }

        public int codigo { get; set; }
        
        [Display(Name = "Nome do grupo")]
        public string nome { get; set; }

        public bool caixa { get; set; }

        public bool lucro { get; set; }

        public int empresaID { get; set; }
    }
}