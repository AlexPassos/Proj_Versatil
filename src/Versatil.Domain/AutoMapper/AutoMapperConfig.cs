using AutoMapper;
using Versatil.Domain.Entities;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
         public AutoMapperConfig()
        {
            //Identity
            CreateMap<Uf, UfViewModel>().ReverseMap();
            CreateMap<Cidades, CidadesViewModel>().ReverseMap();
            CreateMap<Empresas, EmpresasViewModel>().ReverseMap();
            CreateMap<Bancos, BancosViewModel>().ReverseMap();
            CreateMap<Funcionarios, FuncionariosViewModel>().ReverseMap();
            CreateMap<Marcas, MarcasViewModel>().ReverseMap();
            CreateMap<Setores, SetoresViewModel>().ReverseMap();
            CreateMap<Servicos, ServicosViewModel>().ReverseMap();
            CreateMap<Clientes, ClientesViewModel>().ReverseMap();
            CreateMap<Profissoes, ProfissoesViewModel>().ReverseMap();
            CreateMap<ContasDemonstrativos, ContasDemonstrativosViewModel>().ReverseMap();
            CreateMap<ContasGrupos, ContasGruposViewModel>().ReverseMap();
            CreateMap<ContasSubgrupos, ContasSubgruposViewModel>().ReverseMap();
            CreateMap<Contas, ContasViewModel>().ReverseMap();
            CreateMap<Unidades, UnidadesViewModel>().ReverseMap();
            CreateMap<Cfop, CfopViewModel>().ReverseMap();
        }
    }
}