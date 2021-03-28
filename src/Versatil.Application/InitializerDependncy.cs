using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Versatil.Data.Data;
using Microsoft.EntityFrameworkCore;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Data.Repositories;
using Versatil.Domain.Services;
using Versatil.Domain.Interfaces.Services;

namespace Versatil.Application
{
    public static class InitializerDependncy
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
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

            //Serives
            services.AddScoped<IUfService, UfService>();
            services.AddScoped<ICidadesService, CidadesService>();
            services.AddScoped<IEmpresasService, EmpresasService>();
            services.AddScoped<IBancosService, BancosService>();

            return services;
        }

    }
}
