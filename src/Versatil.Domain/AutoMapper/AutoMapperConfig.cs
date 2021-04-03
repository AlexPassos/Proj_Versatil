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
        }
    }
}