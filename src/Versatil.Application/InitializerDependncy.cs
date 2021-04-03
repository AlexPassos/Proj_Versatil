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
            services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();

            //Serives
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUfService, UfService>();
            services.AddScoped<ICidadesService, CidadesService>();
            services.AddScoped<IEmpresasService, EmpresasService>();
            services.AddScoped<IBancosService, BancosService>();
            services.AddScoped<IMarcasService, MarcasService>();
            services.AddScoped<IFuncionariosService, FuncionariosService>();

            return services;
        }

    }
}
