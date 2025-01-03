﻿using DemoResolution.Domain.Interfaces;
using DemoResolution.Infraestructure.Attributes;
using DemoResolution.Infraestructure.Resolution;

namespace DemoResolution.Infraestructure.ResolutionFactories
{
    [ResolutionCode("ResolutionJury")]
    public class ResolutionJuryFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new ResolutionJury();
        }
    }
}
