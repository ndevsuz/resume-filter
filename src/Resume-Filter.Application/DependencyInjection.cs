﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Resume_Filter.Application.Mappers;
using System.Reflection;

namespace Resume_Filter.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(MappingConfiguration));
        return services;
    }
}

