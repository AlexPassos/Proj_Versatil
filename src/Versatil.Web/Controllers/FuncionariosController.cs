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
    public class FuncionariosController : MainController
    {

        private readonly ILogger<FuncionariosController> _logger;
        private readonly IFuncionariosService _funcionariosService;
        private readonly IUfService _ufService;
        private readonly ICidadesService _cidadesService;

        public FuncionariosController(
            INotificador notificador,
            IUser user,
            ILogger<FuncionariosController> logger,
            IUfService ufService,
            ICidadesService cidadesService,
            IFuncionariosService funcionariosService) : base(notificador, user)
        {
            _logger = logger;
            _ufService = ufService;
            _cidadesService = cidadesService;
            _funcionariosService = funcionariosService;
        }

        [HttpGet]
        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Index()
        {
            var model = await _funcionariosService.GetFuncionariosAll();

            return View(model);
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
        public async Task<IActionResult> Create(FuncionariosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                var model = new FuncionariosViewModel();
                model.data = DateTime.Parse(viewModel.strData);
                model.situacao = viewModel.situacao;
                model.nome = viewModel.nome;
                model.cargo = viewModel.cargo;
                model.nascimento = viewModel.nascimento;
                model.rg = viewModel.rg;
                model.cpf = viewModel.cpf;
                model.carteira = viewModel.carteira;
                model.pis = viewModel.pis;
                model.titulo = viewModel.titulo;
                model.habilitacao = viewModel.habilitacao;
                model.reservista = viewModel.reservista;
                model.filiacao = viewModel.filiacao;
                model.admissao = viewModel.admissao;
                model.demissao = viewModel.demissao;
                model.salario = viewModel.salario;
                model.endereco = viewModel.endereco;
                model.numero = viewModel.numero;
                model.complemento = viewModel.complemento;
                model.bairro = viewModel.bairro;
                model.cidadeID = viewModel.cidadeID;
                model.ufID = viewModel.ufID;
                model.cep = viewModel.cep;
                model.telefone = viewModel.telefone;
                model.celular = viewModel.celular;
                model.email = viewModel.email;
                model.obs = viewModel.obs;
                model.empresaID = 1;
                model.nivel = viewModel.nivel;

                if (viewModel.acesso)
                {
                    model.acesso = viewModel.acesso;
                    model.login = viewModel.login;
                    model.senha = viewModel.senha;
                }
                else
                {
                    model.acesso = viewModel.acesso;
                    model.login = "";
                    model.senha = "";
                }


                await _funcionariosService.Salvar(model);

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
            var func = await _funcionariosService.GetFuncionariosId(id);
            ViewBag.Cidades = await DropdownCidade(func.ufID);

            return View(func);
        }

        [HttpPost]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(FuncionariosViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                var model = new FuncionariosViewModel();
                model.id = viewModel.id;
                model.data = DateTime.Parse(viewModel.strData);
                model.situacao = viewModel.situacao;
                model.nome = viewModel.nome;
                model.cargo = viewModel.cargo;
                model.nascimento = viewModel.nascimento;
                model.rg = viewModel.rg;
                model.cpf = viewModel.cpf;
                model.carteira = viewModel.carteira;
                model.pis = viewModel.pis;
                model.titulo = viewModel.titulo;
                model.habilitacao = viewModel.habilitacao;
                model.reservista = viewModel.reservista;
                model.filiacao = viewModel.filiacao;
                model.admissao = viewModel.admissao;
                model.demissao = viewModel.demissao;
                model.salario = viewModel.salario;
                model.endereco = viewModel.endereco;
                model.numero = viewModel.numero;
                model.complemento = viewModel.complemento;
                model.bairro = viewModel.bairro;
                model.cidadeID = viewModel.cidadeID;
                model.ufID = viewModel.ufID;
                model.cep = viewModel.cep;
                model.telefone = viewModel.telefone;
                model.celular = viewModel.celular;
                model.email = viewModel.email;
                model.obs = viewModel.obs;
                model.empresaID = 1;
                model.nivel = viewModel.nivel;
                
                if (viewModel.acesso)
                {
                    model.acesso = viewModel.acesso;
                    model.login = viewModel.login;
                    model.senha = viewModel.senha;
                }
                else
                {
                    model.acesso = viewModel.acesso;
                    model.login = "";
                    model.senha = "";
                }

                if (OperacaoValida())
                {
                    await _funcionariosService.Update(model);
                }

                TempData["Success"] = "Operação realizada com sucesso";
                return RedirectToAction("Index", "Funcionarios");

            }

            TempData["Error"] = "Ops! Falha na solicitação da requisição.";
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            await _funcionariosService.Delete(id);

            var jsonRetorno = new JsonRetorno();
            jsonRetorno.Success = true;
            jsonRetorno.url = Url.Action("Index", "Funcionarios");
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

        public async Task<JsonResult> CepCidade(string codibge)
        {
            var cidade = await _cidadesService.GetCidadeIbge(codibge);
            return Json(cidade);
        }

        public async Task<JsonResult> FuncionariosCPF(string cpf)
        {
            var func = await _funcionariosService.GetFuncionariosCpf(cpf);
            return Json(func);
        }

    }
}