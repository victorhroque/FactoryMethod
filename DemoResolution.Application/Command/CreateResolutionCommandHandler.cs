using DemoResolution.Domain.Interfaces;
using MediatR;

namespace DemoResolution.Application.Command
{
    public class CreateResolutionCommandHandler : IRequestHandler<CreateResolutionCommand, string>
    {
        private readonly IDocumentFactoryProvider _factoryProvider;

        public CreateResolutionCommandHandler(IDocumentFactoryProvider factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }

        public Task<string> Handle(CreateResolutionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IDocumentFactory factory = _factoryProvider.GetFactory(request.ResolutionCode);
                IDocument document = factory.CreateDocument();
                return Task.FromResult(document.CreatePDF(request.StudentCode));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(string.Empty);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(string.Empty);
            }
        }
    }
}
