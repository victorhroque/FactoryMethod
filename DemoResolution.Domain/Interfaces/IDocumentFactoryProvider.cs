namespace DemoResolution.Domain.Interfaces
{
    public interface IDocumentFactoryProvider
    {
        IDocumentFactory GetFactory(string resolutionCode);
    }
}
