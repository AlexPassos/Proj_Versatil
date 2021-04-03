using System;
using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.ViewModels
{
    public class ServicosViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome do serviço")]
        public string descricao { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public Decimal? valor { get; set; }
        public int empresaID { get; set; }
    }
}