using Budgify.Application.Database;
using Budgify.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budgify.Application
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) { 
            services.AddSingleton<IBudgetService,BudgetService>();
            services.AddSingleton<IBudgetRepository, BudgetMemoryDatabase>();
            return services;
        }

    }
}
