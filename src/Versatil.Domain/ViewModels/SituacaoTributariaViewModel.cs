using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class SituacaoTributariaViewModel
    {
        public int id { get; set; }
        public string sitr_pkey { get; set; }
        public string sitr_desc { get; set; }
        public string sitr_tipo { get; set; }

    }
}