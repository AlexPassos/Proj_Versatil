using FluentValidation;
using Versatil.Domain.Entities;

namespace Versatil.Domain.EntitiesValidation
{
    public class BancosValidation : AbstractValidator<Bancos>
    {
        // public BancosValidation(){
        //     RuleFor(x => x.descricao)
        //         .NotEmpty();
        // }
    }
}