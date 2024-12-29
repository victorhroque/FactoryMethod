using DemoResolution.Domain.POCO;

namespace DemoResolution.Domain.Interfaces
{
    public interface IDocument
    {
        DecanalResolution CreatePDF(string studentCode);
    }
}
