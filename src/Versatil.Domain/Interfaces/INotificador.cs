using System.Collections.Generic;
using Versatil.Domain.Notificacoes;

namespace Versatil.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}