﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        return services;
    }
}