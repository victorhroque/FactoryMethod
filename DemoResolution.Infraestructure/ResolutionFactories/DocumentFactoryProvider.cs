using DemoResolution.Domain.Interfaces;
using DemoResolution.Infraestructure.Attributes;
using System.Reflection;

namespace DemoResolution.Infraestructure.ResolutionFactories
{
    public class DocumentFactoryProvider : IDocumentFactoryProvider
    {
        private readonly Dictionary<string, IDocumentFactory> _factories;
        public DocumentFactoryProvider(IEnumerable<IDocumentFactory> factories)
        {
            try
            {
                _factories = factories.ToDictionary(
                    f =>
                    {
                        var attribute = f.GetType().GetCustomAttribute<ResolutionCodeAttribute>();
                        if (attribute == null)
                        {
                            throw new InvalidOperationException($"Factory {f.GetType().Name} is missing ResolutionCodeAttribute.");
                        }
                        return attribute._resolutionCode;
                    },
                    f => f);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing DocumentFactoryProvider: {ex.Message}");
                throw;
            }
        }

        public IDocumentFactory GetFactory(string resolutionCode)
        {
            if (_factories.TryGetValue(resolutionCode, out IDocumentFactory factory))
            {
                return factory;
            }

            throw new ArgumentException($"Factory not found for resolution code: {resolutionCode}");
        }
    }
}
