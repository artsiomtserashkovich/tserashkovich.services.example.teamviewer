using System.Reflection;
using Football.TeamViewer.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Football.TeamViewer.Application.Bootstrapping
{
    public static class BootstrappingExtensions
    {
        public static IServiceCollection AddMediatrSupport(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(BootstrappingExtensions)));

            return services;
        }
        
        public static IServiceCollection AddValidationSupport(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationRequestPipelineHandler<,>));

            return services;
        }
    }
}