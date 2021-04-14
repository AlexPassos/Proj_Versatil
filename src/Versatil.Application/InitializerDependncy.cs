using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Versatil.Data.Data;
using Microsoft.EntityFrameworkCore;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Data.Repositories;
using Versatil.Domain.Services;
using Versatil.Domain.Interfaces.Services;
using Versatil.Domain.Interfaces;
using Versatil.Domain.Notificacoes;
using Versatil.Domain.Extensions;

namespace Versatil.Application
{
    public static class InitializerDependncy
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
             // ASPNET
            services.AddHttpContextAccessor();
            services.AddScoped<IUser, AspNetUser>();
            
            //String conexao
            var DefaultConnectionString = configuration.GetConnectionString("DefaultConnectionString");

            //Conexao
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<DefaultDbContext>(opt => opt.UseNpgsql(DefaultConnectionString));

            //Repository
            services.AddScoped<IUfRepository, UfRepository>();
            services.AddScoped<ICidadesRepository, CidadesRepository>();
            services.AddScoped<IEmpresasRepository, EmpresasRepository>();
            services.AddScoped<IBancosRepository, BancosRepository>();
            services.AddScoped<IMarcasRepository, MarcasRepository>();
            services.AddScoped<ISetoresRepository, SetoresRepository>();
            services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
            services.AddScoped<IServicosRepository, ServicosRepository>();
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IProfissoesRepository, ProfissoesRepository>();
            services.AddScoped<IContasDemonstrativosRepository, ContasDemonstrativosRepository>();
            services.AddScoped<IContasGruposRepository, ContasGruposRepository>();
            services.AddScoped<IContasSubgruposRepository, ContasSubgruposRepository>();
            services.AddScoped<IContasRepository, ContasRepository>();
            services.AddScoped<IUnidadesRepository, UnidadesRepository>();
            services.AddScoped<ICfopRepository, CfopRepository>();
            services.AddScoped<ISituacaoTributariaCofinsRepository, SituacaoTributariaCofinsRepository>();
            services.AddScoped<ISituacaoTributariaIpiRepository, SituacaoTributariaIpiRepository>();
            services.AddScoped<ISituacaoTributariaPisRepository, SituacaoTributariaPisRepository>();
            services.AddScoped<ISituacaoTributariaRepository, SituacaoTributariaRepository>();
            services.AddScoped<IEstoqueCadastroRepository, EstoqueCadastroRepository>();

            //Serives
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUfService, UfService>();
            services.AddScoped<ICidadesService, CidadesService>();
            services.AddScoped<IEmpresasService, EmpresasService>();
            services.AddScoped<IBancosService, BancosService>();
            services.AddScoped<IMarcasService, MarcasService>();
            services.AddScoped<ISetoresService, SetoresService>();
            services.AddScoped<IFuncionariosService, FuncionariosService>();
            services.AddScoped<IServicosService, ServicosService>();
            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<IContasDemonstrativosService, ContasDemonstrativosService>();
            services.AddScoped<IContasGruposService, ContasGruposService>();
            services.AddScoped<IContasSubgruposService, ContasSubgruposService>();
            services.AddScoped<IContasService, ContasService>();
            services.AddScoped<IEstoqueCadastroService, EstoqueCadastroService>();

            return services;
        }

    }
}
