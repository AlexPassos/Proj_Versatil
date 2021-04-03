using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versatil.Domain.Interfaces;
using Versatil.Domain.Notificacoes;

namespace Versatil.Web.Controllers
{
    public abstract class MainController : Controller
    {

        private readonly INotificador _notificador;
        protected IUser UserCustom { get; init; }

        protected MainController(
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

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected IActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        protected IActionResult WebApiResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected IActionResult WebApiResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotificarErroModelInvalida(modelState);

            return WebApiResponse();
        }

        private void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                Notificar(errorMsg);
            }
        }

        protected void ClearCookies()
        {
            foreach (var cookieKey in Request.Cookies.Keys)
                Response.Cookies.Delete(cookieKey);
        }

        protected ICollection<string> GetErrosModelState()
        {
            var models = new List<string>();
            foreach (var state in ModelState.Values)
            {
                foreach (var erro in state.Errors)
                {
                    models.Add(erro.ErrorMessage);
                }
            }

            return models;
        }
    }
}
