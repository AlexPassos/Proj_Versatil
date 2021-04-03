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
    public class MarcasController : MainController
    {

        private readonly ILogger<MarcasController> _logger;
        private readonly IMarcasService _marcasService;

        public MarcasController(
            INotificador notificador,
            IUser user,
            ILogger<MarcasController> logger,
            IMarcasService marcasService) : base(notificador, user)
        {
            _logger = logger;
            _marcasService = marcasService;
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var modelMarcas = await _marcasService.GetMarcasAll();
            return View(modelMarcas);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(MarcasViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var model = new MarcasViewModel();
                model.descricao = viewModel.descricao;
                model.empresaID = 1;

                await _marcasService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Marcas");

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Marcas");
        }

        [HttpGet]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(int id)
        {
            var banco = await _marcasService.GetMarcaId(id);
            return View(banco);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(MarcasViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var model = new MarcasViewModel();
                model.id = viewModel.id;
                model.descricao = viewModel.descricao;
                model.empresaID = 1;

                await _marcasService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Marcas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Marcas");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _marcasService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Marcas");
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