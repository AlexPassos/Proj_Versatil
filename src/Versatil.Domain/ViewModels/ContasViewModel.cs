using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class ContasViewModel
    {
        public int id { get; set; }

        public int contasdemonstrativosID { get; set; }
        [Display(Name = "Escolha o grupo")]
        public int contasgruposID { get; set; }
        [Display(Name = "Escolha o subgrupo")]
        public int contassubgruposID { get; set; }

        public int codigo { get; set; }

        [Display(Name = "Nome da conta")]
        public string nome { get; set; }

        public bool caixa { get; set; }

        public bool lucro { get; set; }
        public bool situacao { get; set; }

        public int empresaID { get; set; }
    }
}