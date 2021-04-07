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
    public class ClientesController : MainController
    {

        private readonly ILogger<ClientesController> _logger;
        private readonly IClientesService _clientesService;
        private readonly IUfService _ufService;
        private readonly ICidadesService _cidadesService;

        public ClientesController(
            INotificador notificador,
            IUser user,
            ILogger<ClientesController> logger,
            IUfService ufService,
            ICidadesService cidadesService,
            IClientesService clientesService) : base(notificador, user)
        {
            _logger = logger;
            _ufService = ufService;
            _cidadesService = cidadesService;
            _clientesService = clientesService;
        }

        [HttpGet]
        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var model = await _clientesService.GetClientesAll();

            return View(model);
        }

        [HttpGet]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ClientesViewModel();

            ViewBag.Estados = await DropdownUf();
            ViewBag.Profissoes = await DropdownProfissoes();
            return View(viewModel);
        }

        [HttpPost]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        public async Task<IActionResult> Create(ClientesViewModel viewModel)
        {
            
                if (ModelState.IsValid)
                {

                    var model = new ClientesViewModel();
                    model.datacad = DateTime.Parse(viewModel.strData);
                    model.tipo = viewModel.tipo;
                    model.situacao = viewModel.situacao;
                    model.nome = viewModel.nome;
                    model.sexo = viewModel.sexo;
                    model.nascimento = viewModel.nascimento;
                    model.civil = viewModel.civil;
                    model.profissaoID = viewModel.profissaoID;
                    model.fantasia = viewModel.fantasia;
                    model.rgie = viewModel.rgie;
                    model.orgaoemissor = viewModel.orgaoemissor;
                    model.dataemissao = viewModel.dataemissao;
                    model.cpfcnpj = viewModel.cpfcnpj;
                    model.sitlimite = viewModel.sitlimite;
                    model.limite = viewModel.limite;
                    model.endereco = viewModel.endereco;
                    model.numero = viewModel.numero;
                    model.complemento = viewModel.complemento;
                    model.bairro = viewModel.bairro;
                    model.cidadeID = viewModel.cidadeID;
                    model.ufID = viewModel.ufID;
                    model.cep = viewModel.cep;
                    model.telefone = viewModel.telefone;
                    model.celularfax = viewModel.celularfax;
                    model.email = viewModel.email;
                    model.obs = viewModel.obs;
                    model.cod = viewModel.cod;
                    model.empresaID = 1;

                    await _clientesService.Salvar(model);

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
            ViewBag.Estados = await DropdownUf();
            ViewBag.Profissoes = await DropdownProfissoes();
            var func = await _clientesService.GetClientesId(id);
            ViewBag.Cidades = await DropdownCidade(func.ufID);

            return View(func);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(ClientesViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                await _clientesService.Update(viewModel);

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Clientes");

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _clientesService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Clientes");
            jsonRetorno.Messages.Add("Operação realizada com sucesso");

            return Json(jsonRetorno);

        }

        private async Task<SelectList> DropdownUf()
        {
            var uf = await _ufService.GetUfAll();
            return new SelectList(uf, "id", "sigla");
        }
        private async Task<SelectList> DropdownProfissoes()
        {
            var prof = await _clientesService.GetProfissoes();
            return new SelectList(prof, "id", "descricao");
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

        public async Task<JsonResult> CepCidade(string codibge)
        {
            var cidade = await _cidadesService.GetCidadeIbge(codibge);
            return Json(cidade);
        }

        public async Task<JsonResult> ClientesCPF(string cpf)
        {
            var func = await _clientesService.GetClientesCpf(cpf);
            return Json(func);
        }

    }
}