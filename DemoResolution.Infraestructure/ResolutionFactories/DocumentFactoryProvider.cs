using DemoResolution.Domain.Interfaces;

namespace DemoResolution.Infraestructure.ResolutionFactories
{
    public class DocumentFactoryProvider : IDocumentFactoryProvider
    {
        private readonly Dictionary<string, IDocumentFactory> _factories = new();
        public DocumentFactoryProvider(ResolutionJuryFactory resolutionJuryFactory)
        {
            _factories.Add("ResolutionJury", resolutionJuryFactory);
        }

        public IDocumentFactory GetFactory(string resolutionCode)
        {
            if(_factories.TryGetValue(resolutionCode, out IDocumentFactory factory))
            {
                return factory;
            }

            throw new ArgumentException($"Factory not found for resolution code: {resolutionCode}");
        }
    }
}
