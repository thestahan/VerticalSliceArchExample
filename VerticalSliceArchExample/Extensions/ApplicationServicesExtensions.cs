using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VerticalSliceArchExample.Behaviors;
using VerticalSliceArchExample.Data;

namespace VerticalSliceArchExample.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(currentAssembly);

        services.AddMediatR(currentAssembly);

        services.AddValidatorsFromAssembly(currentAssembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("VerticalSliceArchDB"));

        return services;
    }
}
