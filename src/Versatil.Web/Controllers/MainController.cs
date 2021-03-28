using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Versatil.Web.Controllers
{
    public abstract class MainController : Controller
    {

        protected IActionResult RedurectToLocal(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        protected ICollection<string> GetErrosModelState()
        {
            var models = new List<string>();
            foreach(var state in ModelState.Values)
            {
                foreach(var erro in state.Errors)
                {
                    models.Add(erro.ErrorMessage);
                }
            }

            return models;
        }
    }
}
