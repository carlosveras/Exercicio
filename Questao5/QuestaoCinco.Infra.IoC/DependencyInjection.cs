using QuestaoCinco.Application.Interfaces;
using QuestaoCinco.Application.Mappings;
using QuestaoCinco.Application.Services;
using QuestaoCinco.Domain.Interfaces;
using QuestaoCinco.Infra.Data.Context;
using QuestaoCinco.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace QuestaoCinco.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
            services.AddScoped<ILancamentoService, LancamentoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("QuestaoCinco.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
