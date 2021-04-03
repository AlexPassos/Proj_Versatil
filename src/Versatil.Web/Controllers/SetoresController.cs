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
    public class SetoresController : MainController
    {

        private readonly ILogger<SetoresController> _logger;
        private readonly ISetoresService _setoresService;

        public SetoresController(
            INotificador notificador,
            IUser user,
            ILogger<SetoresController> logger,
            ISetoresService setoresService) : base(notificador, user)
        {
            _logger = logger;
            _setoresService = setoresService;
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var modelSetores = await _setoresService.GetSetoresAll();
            return View(modelSetores);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(SetoresViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var model = new SetoresViewModel();
                model.descricao = viewModel.descricao;
                model.empresaID = 1;

                await _setoresService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Setores");

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Setores");
        }

        [HttpGet]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(int id)
        {
            var setor = await _setoresService.GetSetorId(id);
            return View(setor);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(SetoresViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var model = new SetoresViewModel();
                model.id = viewModel.id;
                model.descricao = viewModel.descricao;
                model.empresaID = 1;

                await _setoresService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Setores");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Setores");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _setoresService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Setores");
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