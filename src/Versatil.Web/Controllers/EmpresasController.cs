using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using Versatil.Domain.Interfaces.Services;
using Versatil.Domain.ViewModels;
using Versatil.Web.Models;

namespace Versatil.Web.Controllers
{
    public class EmpresasController : MainController
    {

        private readonly ILogger<EmpresasController> _logger;
        private readonly IEmpresasService _empresasService;
        private readonly IUfService _ufService;
        private readonly ICidadesService _cidadesService;

        public EmpresasController(
            ILogger<EmpresasController> logger,
            IUfService ufService,
            ICidadesService cidadesService,
            IEmpresasService empresasService
            )
        {
            _logger = logger;
            _ufService = ufService;
            _cidadesService = cidadesService;
            _empresasService = empresasService;
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var modelEmpresas = await _empresasService.GetEmpresasAll();

            return View(modelEmpresas);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create()
        {
            ViewBag.Estados = await DropdownUf();
            return View();
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(EmpresasViewModel viewModel)
        {

            var jsonRetorno = new JsonRetorno();

            if (!ModelState.IsValid)
            {
                jsonRetorno.Messages = GetErrosModelState();
                return Json(jsonRetorno);
            }

            if (ModelState.IsValid)
            {
                var model = new EmpresasViewModel();
                model.razao = viewModel.razao;
                model.fantasia = viewModel.fantasia;
                model.ie = viewModel.ie;
                model.cnpj = viewModel.cnpj;
                model.endereco = viewModel.endereco;
                model.numero = viewModel.numero;
                model.complemento = viewModel.complemento;
                model.bairro = viewModel.bairro;
                model.cidadeID = viewModel.cidadeID;
                model.ufID = viewModel.ufID;
                model.cep = viewModel.cep;
                model.telefone = viewModel.telefone;
                model.fax = viewModel.fax;
                model.email = viewModel.email;

                await _empresasService.Salvar(model);

                //TempData["Success"] = "Operação realizada com sucesso";
                jsonRetorno.Success = true;
                jsonRetorno.url = Url.Action("Index", "Empresas");
                jsonRetorno.Messages.Add("Operação realizada com sucesso");

                //return RedirectToAction(nameof(Index), jsonRetorno);
                return Json(jsonRetorno);

            }

            jsonRetorno.Messages = GetErrosModelState();
            return Json(jsonRetorno);
        }

        [HttpGet]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Estados = await DropdownUf();
            var banco = await _empresasService.GetEmpresaId(id);
            ViewBag.Cidades = await DropdownCidade(banco.ufID);
            return View(banco);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(EmpresasViewModel viewModel)
        {

            var jsonRetorno = new JsonRetorno();

            if (!ModelState.IsValid)
            {
                jsonRetorno.Messages = GetErrosModelState();
                return Json(jsonRetorno);
            }

            if (ModelState.IsValid)
            {
                // var model = new EmpresasViewModel();
                // model.id = viewModel.id;
                // model.descricao = viewModel.descricao;
                // model.empresaID = 1;

                await _empresasService.Update(viewModel);

                jsonRetorno.Success = true;
                jsonRetorno.url = Url.Action("Index", "Empresas");
                jsonRetorno.Messages.Add("Operação realizada com sucesso");

                return Json(jsonRetorno);

            }

            jsonRetorno.Messages = GetErrosModelState();
            return Json(jsonRetorno);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _empresasService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Empresas");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);

        }

        private async Task<SelectList> DropdownUf()
        {
            var uf = await _ufService.GetUfAll();
            return new SelectList(uf, "id", "sigla");
        }

        private async Task<SelectList> DropdownCidade(int idestado)
        {
            var cidades = await _cidadesService.GetCidades(idestado);
            return new SelectList(cidades, "id", "nome");
        }

        public async Task<JsonResult> DropdownCidades(int idestado)
        {
            var cidades = await _cidadesService.GetCidades(idestado);
            return Json(cidades);

        }
        //[Breadcrumb("ViewData.Title",  FromAction = nameof(Index))]

    }
}