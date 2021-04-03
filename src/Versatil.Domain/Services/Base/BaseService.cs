using Versatil.Domain.Interfaces;
using Versatil.Domain.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Versatil.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        protected IUser UserCustom { get; init; }

        protected BaseService(
            INotificador notificador,
            IUser user)
        {
            _notificador = notificador;
            UserCustom = user;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }
    }
}