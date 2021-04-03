using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using Versatil.Domain.Interfaces;
using Versatil.Domain.Interfaces.Services;
using Versatil.Domain.ViewModels;
using Versatil.Web.Models;

namespace Versatil.Web.Controllers
{
    public class ServicosController : MainController
    {

        private readonly ILogger<ServicosController> _logger;
        private readonly IServicosService _servicosService;

        public ServicosController(
            INotificador notificador,
            IUser user,
            ILogger<ServicosController> logger,
            IServicosService servicosService) : base(notificador, user)
        {
            _logger = logger;
            _servicosService = servicosService;
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var modelServicos = await _servicosService.GetServicosAll();
            return View(modelServicos);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(ServicosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var model = new ServicosViewModel();
                model.descricao = viewModel.descricao;
                model.valor = viewModel.valor;
                model.empresaID = 1;

                await _servicosService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Servicos");

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Servicos");
        }

        [HttpGet]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(int id)
        {
            var servico = await _servicosService.GetServicoId(id);
            return View(servico);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(ServicosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var model = new ServicosViewModel();
                model.id = viewModel.id;
                model.descricao = viewModel.descricao;
                model.valor = viewModel.valor;
                model.empresaID = 1;

                await _servicosService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Servicos");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Servicos");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _servicosService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Servicos");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}