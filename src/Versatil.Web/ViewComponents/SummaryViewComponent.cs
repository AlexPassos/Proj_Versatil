using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Versatil.Domain.Interfaces;

namespace Versatil.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            foreach (var item in notificacoes)
            {
                ViewData.ModelState.AddModelError(string.Empty, item.Mensagem);
            }

            return View();
        }
    }
}