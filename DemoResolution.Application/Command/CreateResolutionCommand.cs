using MediatR;

namespace DemoResolution.Application.Command
{
    public class CreateResolutionCommand : IRequest<string>
    {
        public string ResolutionCode { get; set; }
        public string StudentCode { get; set; }

        public CreateResolutionCommand(string resolutionCode, string studentCode)
        {
            ResolutionCode = resolutionCode;
            StudentCode = studentCode;
        }
    }
}
