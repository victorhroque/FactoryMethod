using DemoResolution.Domain.Interfaces;
using System.Diagnostics;

namespace DemoResolution.Infraestructure.Resolution
{
    public class ResolutionJury : IDocument
    {
        public string CreatePDF(string studentCode)
        {
            Debug.WriteLine($"Creando PDF de designación de jurado para: {studentCode}");
            return $"{Guid.NewGuid()}.pdf";
        }
    }
}
