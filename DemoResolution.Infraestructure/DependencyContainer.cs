using DemoResolution.Domain.Interfaces;
using DemoResolution.Infraestructure.Attributes;
using DemoResolution.Infraestructure.Resolution;
using DemoResolution.Infraestructure.ResolutionFactories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace DemoResolution.Infraestructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterFactories(this IServiceCollection services)
        {
            services.AddScoped<IDocumentFactoryProvider, DocumentFactoryProvider>();

            var factoryTypes = typeof(DocumentFactoryProvider).Assembly // Obtener el ensamblado donde están las fábricas
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IDocumentFactory).IsAssignableFrom(t) &&
                    t.GetCustomAttribute<ResolutionCodeAttribute>() != null); // Filtrar solo las clases que implementan IDocumentFactory y tienen el atributo ResolutionCodeAttribute

            Debug.WriteLine($"Se encontraron {factoryTypes.Count()} tipos de fábrica con atributo ResolutionCodeAttribute.");

            foreach (var factoryType in factoryTypes)
            {
                services.AddScoped(typeof(IDocumentFactory), factoryType);
                Debug.WriteLine($"Registrando {factoryType.Name} como IDocumentFactory");
            }

            //services.AddScoped<IDocumentFactory, ResolutionJuryFactory>();
            //services.AddScoped<IDocumentFactory, ResolutionAdviserFactory>();
            return services;
        }
    }
}
