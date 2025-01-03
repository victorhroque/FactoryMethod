﻿using DemoResolution.Domain.Interfaces;
using DemoResolution.Domain.POCO;
using System.Diagnostics;

namespace DemoResolution.Infraestructure.Resolution
{
    public class ResolutionJury : IDocument
    {
        public DecanalResolution CreatePDF(string studentCode)
        {
            Debug.WriteLine($"Creando PDF de designación de jurado para: {studentCode}");
            return new DecanalResolution
            {
                Code = Guid.NewGuid().ToString(),
                StudentCode = studentCode,
                Description = "Designación de jurado",
                FilePath = $"{Guid.NewGuid()}.pdf"
            };
        }
    }
}
