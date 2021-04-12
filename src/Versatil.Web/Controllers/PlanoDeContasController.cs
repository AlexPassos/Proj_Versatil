using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using Versatil.Domain.Interfaces;
using Versatil.Domain.Interfaces.Services;
using Versatil.Domain.ViewModels;
using Versatil.Web.Models;

namespace Versatil.Web.Controllers
{
    public class PlanoDeContasController : MainController
    {

        private readonly ILogger<PlanoDeContasController> _logger;
        private readonly IContasDemonstrativosService _demonstrativosService;
        private readonly IContasGruposService _gruposService;
        private readonly IContasSubgruposService _subgruposService;
        private readonly IContasService _contasService;

        public PlanoDeContasController(
            INotificador notificador,
            IUser user,
            ILogger<PlanoDeContasController> logger,
            IContasDemonstrativosService demonstrativosService,
            IContasGruposService gruposService,
            IContasSubgruposService subgruposService,
            IContasService contasService
            ) : base(notificador, user)
        {
            _logger = logger;
            _demonstrativosService = demonstrativosService;
            _gruposService = gruposService;
            _subgruposService = subgruposService;
            _contasService = contasService;
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var model = new PlanoContasViewModel();

            var modelDemo = await _demonstrativosService.GetDemonstrativoId(1);
            model.Demonstrativo = modelDemo;

            return View(model);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar grupo", FromAction = nameof(Index))]
        public IActionResult CreateGrupo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrupo(ContasGruposViewModel gruposModel)
        {
            if (ModelState.IsValid)
            {
                int codigo = _gruposService.GetMaxCodigo() + 1;

                var model = new ContasGruposViewModel();
                model.contasdemonstrativosID = 1;
                model.codigo = codigo;
                model.nome = gruposModel.nome;
                model.caixa = true;
                model.lucro = false;
                model.empresaID = 1;

                await _gruposService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "PlanoDeContas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "PlanoDeContas");
        }

        [HttpGet]
        [Breadcrumb("Editar grupo", FromAction = nameof(Index))]
        public async Task<IActionResult> EditGrupo(int id)
        {
            var model = await _gruposService.GetGrupoId(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditGrupo(ContasGruposViewModel gruposModel)
        {
            if (ModelState.IsValid)
            {
                var model = new ContasGruposViewModel();
                model.id = gruposModel.id;
                model.contasdemonstrativosID = 1;
                model.codigo = gruposModel.codigo;
                model.nome = gruposModel.nome;
                model.caixa = true;
                model.lucro = false;
                model.empresaID = 1;

                await _gruposService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "PlanoDeContas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "PlanoDeContas");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            await _gruposService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "PlanoDeContas");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar subgrupo", FromAction = nameof(Index))]
        public async Task<IActionResult> CreateSubgrupo()
        {
            var viewModel = new ContasSubgruposViewModel();
            ViewBag.Grupos = await CarregaGrupos();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubgrupo(ContasSubgruposViewModel subgruposModel)
        {
            if (ModelState.IsValid)
            {

                int codigo = _subgruposService.GetMaxCodigo(subgruposModel.contasgruposID) + 1;

                var model = new ContasSubgruposViewModel();
                model.contasdemonstrativosID = 1;
                model.contasgruposID = subgruposModel.contasgruposID;
                model.codigo = codigo;
                model.nome = subgruposModel.nome;
                model.caixa = true;
                model.lucro = false;
                model.empresaID = 1;

                await _subgruposService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "PlanoDeContas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "PlanoDeContas");
        }

        [HttpGet]
        [Breadcrumb("Editar subgrupo", FromAction = nameof(Index))]
        public async Task<IActionResult> EditSubgrupo(int id)
        {
            var viewModel = await _subgruposService.GetSubgrupoId(id);
            ViewBag.Grupos = await CarregaGrupos();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubgrupo(ContasSubgruposViewModel subgruposModel)
        {
            if (ModelState.IsValid)
            {                
                var model = new ContasSubgruposViewModel();
                model.id = subgruposModel.id;
                model.contasdemonstrativosID = 1;
                model.contasgruposID = subgruposModel.contasgruposID;
                model.codigo = subgruposModel.codigo;
                model.nome = subgruposModel.nome;
                model.caixa = true;
                model.lucro = false;
                model.empresaID = 1;

                await _subgruposService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "PlanoDeContas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "PlanoDeContas");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubgrupo(int id)
        {
            await _subgruposService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "PlanoDeContas");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar contas", FromAction = nameof(Index))]
        public async Task<IActionResult> CreateConta()
        {
            var viewModel = new ContasViewModel();
            ViewBag.Grupos = await CarregaGrupos();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConta(ContasViewModel contasModel)
        {
            if (ModelState.IsValid)
            {

                int codigo = _contasService.GetMaxCodigo(contasModel.contasgruposID, contasModel.contassubgruposID) + 1;

                var model = new ContasViewModel();
                model.contasdemonstrativosID = 1;
                model.contasgruposID = contasModel.contasgruposID;
                model.contassubgruposID = contasModel.contassubgruposID;
                model.codigo = codigo;
                model.nome = contasModel.nome;
                model.caixa = true;
                model.lucro = false;
                model.situacao = true;
                model.empresaID = 1;

                await _contasService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "PlanoDeContas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "PlanoDeContas");
        }

        [HttpGet]
        [Breadcrumb("Editar contas", FromAction = nameof(Index))]
        public async Task<IActionResult> EditConta(int id)
        {
            ViewBag.Grupos = await CarregaGrupos();
            var viewModel = await _contasService.GetContaId(id);
            ViewBag.Subgrupos = await CarregaSubgruposEdit(viewModel.contasgruposID);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditConta(ContasViewModel contasModel)
        {
            if (ModelState.IsValid)
            {                

                var model = new ContasViewModel();
                model.id = contasModel.id;
                model.contasdemonstrativosID = 1;
                model.contasgruposID = contasModel.contasgruposID;
                model.contassubgruposID = contasModel.contassubgruposID;
                model.codigo = contasModel.codigo;
                model.nome = contasModel.nome;
                model.caixa = true;
                model.lucro = false;
                model.situacao = true;
                model.empresaID = 1;

                await _contasService.Update(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "PlanoDeContas");
            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction("Index", "PlanoDeContas");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConta(int id)
        {
            await _contasService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "PlanoDeContas");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);
        }

        private async Task<SelectList> CarregaGrupos()
        {
            var uf = await _gruposService.GetGrupos(1);
            return new SelectList(uf, "id", "nome");
        }

        public async Task<SelectList> CarregaSubgruposEdit(int idgrupo)
        {
            var sbg = await _subgruposService.GetSubgrupos(idgrupo);
            return new SelectList(sbg, "id", "nome");

        }

        public async Task<JsonResult> CarregaSubgrupos(int idgrupo)
        {
            var sbg = await _subgruposService.GetSubgrupos(idgrupo);
            return Json(sbg);

        }

    }
}