using System;
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
    public class EstoqueCadastroController : MainController
    {

        private readonly ILogger<EstoqueCadastroController> _logger;
        private readonly IEstoqueCadastroService _cadastroService;
        private readonly IUfService _ufService;
        private readonly ICidadesService _cidadesService;

        public EstoqueCadastroController(
            INotificador notificador,
            IUser user,
            ILogger<EstoqueCadastroController> logger,
            IUfService ufService,
            ICidadesService cidadesService,
            IEstoqueCadastroService cadastroService) : base(notificador, user)
        {
            _logger = logger;
            _ufService = ufService;
            _cidadesService = cidadesService;
            _cadastroService = cadastroService;
        }

        [HttpGet]
        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var model = await _cadastroService.GetEstoqueCadastroAll();

            return View(model);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create()
        {
            var viewModel = new EstoqueCadastroViewModel();

            ViewBag.Unidades = await CarregaUnidades();
            ViewBag.Marcas = await CarregaMarcas();
            ViewBag.Cfop = await CarregaCFOP();
            ViewBag.Icms = await CarregaIcms();
            ViewBag.Pis = await CarregaPis();
            ViewBag.Cofins = await CarregaCofins();
            ViewBag.Ipi = await CarregaIpi();

            return View(viewModel);
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(EstoqueCadastroViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                var model = new EstoqueCadastroViewModel();
                //model.datacad = DateTime.Parse(viewModel.datacad);                    
                model.situacao = viewModel.situacao;
                model.datacad = viewModel.datacad;
                model.descricao = viewModel.descricao;
                model.unidadesID = viewModel.unidadesID;
                model.marcasID = viewModel.marcasID;
                model.ncm = viewModel.ncm;
                model.cfopID = viewModel.cfopID;
                model.peso = viewModel.peso;
                model.comissao = viewModel.comissao;
                model.valor = viewModel.valor;
                model.obs = viewModel.obs;
                model.tribicmsID = viewModel.tribicmsID;
                model.aliquotacredito = viewModel.aliquotacredito;
                model.aliquotabaseicms = viewModel.aliquotabaseicms;
                model.aliquotaicms = viewModel.aliquotaicms;
                model.pautafiscal = viewModel.pautafiscal;
                model.aliquotabaseicmsst = viewModel.aliquotabaseicmsst;
                model.aliquotaicmsst = viewModel.aliquotaicmsst;
                model.tribpisID = viewModel.tribpisID;
                model.aliquotapis = viewModel.aliquotapis;
                model.tribcofinsID = viewModel.tribcofinsID;
                model.aliquotacofins = viewModel.aliquotacofins;
                model.tribipiID = viewModel.tribipiID;
                model.aliquotaipi = viewModel.aliquotaipi;
                model.aliquotaiss = viewModel.aliquotaiss;
                model.cod = viewModel.cod;
                model.empresaID = 1;
                model.cest = viewModel.cest;
                await _cadastroService.Salvar(model);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction(nameof(Index));

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Unidades = await CarregaUnidades();
            ViewBag.Marcas = await CarregaMarcas();
            ViewBag.Cfop = await CarregaCFOP();
            ViewBag.Icms = await CarregaIcms();
            ViewBag.Pis = await CarregaPis();
            ViewBag.Cofins = await CarregaCofins();
            ViewBag.Ipi = await CarregaIpi();

            var func = await _cadastroService.GetEstoqueCadastroId(id);

            return View(func);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(EstoqueCadastroViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                await _cadastroService.Update(viewModel);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "EstoqueCadastro");

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _cadastroService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "EstoqueCadastro");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);

        }

        private async Task<SelectList> CarregaUnidades()
        {
            var unidades = await _cadastroService.GetUnidades();
            return new SelectList(unidades, "id", "descricao");
        }
        private async Task<SelectList> CarregaMarcas()
        {
            var marcas = await _cadastroService.GetMarcas();
            return new SelectList(marcas, "id", "descricao");
        }

        private async Task<SelectList> CarregaCFOP()
        {
            var cfop = await _cadastroService.GetCFOP();
            return new SelectList(cfop, "id", "cfop");
        }
        private async Task<SelectList> CarregaIcms()
        {
            var m = await _cadastroService.GetICMS();
            return new SelectList(m, "id", "sitr_desc");
        }
        private async Task<SelectList> CarregaPis()
        {
            var p = await _cadastroService.GetPIS();
            return new SelectList(p, "id", "descricao");
        }
        private async Task<SelectList> CarregaCofins()
        {
            var c = await _cadastroService.GetCOFINS();
            return new SelectList(c, "id", "descricao");
        }
        private async Task<SelectList> CarregaIpi()
        {
            var v = await _cadastroService.GetIPI();
            return new SelectList(v, "id", "descricao");
        }



    }
}