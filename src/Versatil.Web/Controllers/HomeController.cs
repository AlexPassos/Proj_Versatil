using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.Interfaces.Services;
using Versatil.Web.Models;

namespace Versatil.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUfService _ufService;
        private readonly ICidadesService _cidadesService;
      

        public HomeController(
            ILogger<HomeController> logger, 
            IUfService ufService,
            ICidadesService cidadesService
            )
        {
            _logger = logger;
            _ufService = ufService;
            _cidadesService = cidadesService;
          
        }

        [DefaultBreadcrumb("Home")]
        public async Task<IActionResult> Index()
        {
            ViewData["FooterEmpresa"] = "Empresa logada";

            //var model = await _ufService.GetUfAll();
            //var modelCidade = await _cidadesService.GetCidadesAll();
          

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
