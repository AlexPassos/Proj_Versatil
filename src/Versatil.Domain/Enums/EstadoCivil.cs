using System.ComponentModel.DataAnnotations;

namespace Versatil.Domain.Enums
{
    public enum EstadoCivil
    {
        [Display(Name = "Selecione")] Selecione = 0,
        [Display(Name = "Solteiro(a)")] Solteiro = 1,

        [Display(Name = "Casado(a)")] Casado = 2,

        [Display(Name = "Viúvo(a)")] Viúvo = 3,

        [Display(Name = "Desquitado(a)")] Desquitado = 4,

        [Display(Name = "Divorciado(a)")] Divorciado = 5,

        [Display(Name = "Outro")] Outro = 6,
    }
}