using DemoResolution.Domain.Interfaces;
using DemoResolution.Infraestructure.Attributes;
using DemoResolution.Infraestructure.Resolution;

namespace DemoResolution.Infraestructure.ResolutionFactories
{
    [ResolutionCode("ResolutionAdviser")]
    public class ResolutionAdviserFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new ResolutionAdviser();
        }
    }
}
