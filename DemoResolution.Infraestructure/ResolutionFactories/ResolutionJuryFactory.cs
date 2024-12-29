using DemoResolution.Domain.Interfaces;
using DemoResolution.Infraestructure.Resolution;

namespace DemoResolution.Infraestructure.ResolutionFactories
{
    public class ResolutionJuryFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new ResolutionJury();
        }
    }
}
