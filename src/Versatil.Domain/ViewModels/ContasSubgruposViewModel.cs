using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class ContasSubgruposViewModel
    {
        public int id { get; set; }

        public int contasdemonstrativosID { get; set; }
        [Display(Name = "Escolha o grupo")]
        public int contasgruposID { get; set; }

        public int codigo { get; set; }

        [Display(Name = "Nome do subgrupo")]
        public string nome { get; set; }

        public bool caixa { get; set; }

        public bool lucro { get; set; }

        public int empresaID { get; set; }
    }
}