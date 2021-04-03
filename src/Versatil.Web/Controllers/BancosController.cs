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
    public class BancosController : MainController
    {

        private readonly ILogger<BancosController> _logger;
        private readonly IBancosService _bancosService;

        public BancosController(
            INotificador notificador,
            IUser user,
            ILogger<BancosController> logger,
            IBancosService bancosService) : base(notificador, user)
        {
            _logger = logger;
            _bancosService = bancosService;
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var modelBancos = await _bancosService.GetBancosAll();
            return View(modelBancos);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(BancosViewModel viewModel)
        {

            //var jsonRetorno = new JsonRetorno();

            if (ModelState.IsValid)
            {
                var model = new BancosViewModel();
                model.descricao = viewModel.descricao;
                model.empresaID = 1;

                await _bancosService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                // jsonRetorno.Success = true;
                // jsonRetorno.url = Url.Action("Index", "Bancos");
                // jsonRetorno.Messages.Add("Operação realizada com sucesso");

                return RedirectToAction("Index", "Bancos");
                //return Json(jsonRetorno);

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Bancos");
        }

        [HttpGet]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(int id)
        {
            var banco = await _bancosService.GetBancoId(id);
            return View(banco);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(BancosViewModel viewModel)
        {

            //var jsonRetorno = new JsonRetorno();

            if (ModelState.IsValid)
            {
                var model = new BancosViewModel();
                model.id = viewModel.id;
                model.descricao = viewModel.descricao;
                model.empresaID = 1;

                await _bancosService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Bancos");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "Bancos");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _bancosService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Bancos");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);

        }

        //[Breadcrumb("ViewData.Title",  FromAction = nameof(Index))]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}