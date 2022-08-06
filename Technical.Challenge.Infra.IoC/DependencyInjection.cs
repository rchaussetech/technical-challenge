using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Technical.Challenge.Application.Interfaces;
using Technical.Challenge.Application.Mappings;
using Technical.Challenge.Application.Services;
using Technical.Challenge.Domain.Interfaces;
using Technical.Challenge.Infra.Data.Computers;

namespace Technical.Challenge.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDecomposeNumberService, DecomposeNumberService>();
            services.AddTransient<IPrimeNumberService, PrimeNumberService>();

            services.AddTransient<IDecomposeNumberComputer, DecomposeNumberComputer>();
            services.AddTransient<IPrimeNumberComputer, PrimeNumberComputer>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToDomainMappingProfile));

            Assembly myHandlers = AppDomain.CurrentDomain.Load("Technical.Challenge.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}