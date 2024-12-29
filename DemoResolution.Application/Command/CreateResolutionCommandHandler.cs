using DemoResolution.Domain.Interfaces;
using DemoResolution.Domain.POCO;
using DemoResolution.Domain.Wrappers;
using MediatR;
using System.Diagnostics;

namespace DemoResolution.Application.Command
{
    public class CreateResolutionCommandHandler : IRequestHandler<CreateResolutionCommand, AppResponse<DecanalResolution>>
    {
        private readonly IDocumentFactoryProvider _factoryProvider;

        public CreateResolutionCommandHandler(IDocumentFactoryProvider factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }

        public Task<AppResponse<DecanalResolution>> Handle(CreateResolutionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IDocumentFactory factory = _factoryProvider.GetFactory(request.ResolutionCode);
                IDocument document = factory.CreateDocument();
                var response = new AppResponse<DecanalResolution>
                {
                    IsSuccess = true,
                    Data = document.CreatePDF(request.StudentCode),
                    Message = $"Documento generado para el estudiante {request.StudentCode} de tipo {request.ResolutionCode}"
                };
                return Task.FromResult(response);
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                var response = new AppResponse<DecanalResolution>
                {
                    IsSuccess = false,
                    Message = "Tipo de documento no válido"
                };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var response = new AppResponse<DecanalResolution>
                {
                    IsSuccess = false,
                    Message = "Error inesperado"
                };
                return Task.FromResult(response);
            }
        }
    }
}
