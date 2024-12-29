using DemoResolution.Domain.Interfaces;
using DemoResolution.Domain.POCO;
using System.Diagnostics;

namespace DemoResolution.Infraestructure.Resolution
{
    public class ResolutionAdviser : IDocument
    {
        public DecanalResolution CreatePDF(string studentCode)
        {
            Debug.WriteLine($"Creando PDF de designación de asesor para: {studentCode}");
            return new DecanalResolution
            {
                Code = Guid.NewGuid().ToString(),
                StudentCode = studentCode,
                Description = "Designación de asesor",
                FilePath = $"{Guid.NewGuid()}.pdf"
            };
        }
    }
}
