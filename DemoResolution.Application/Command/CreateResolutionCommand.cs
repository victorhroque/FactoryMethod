using DemoResolution.Domain.POCO;
using DemoResolution.Domain.Wrappers;
using MediatR;

namespace DemoResolution.Application.Command
{
    public class CreateResolutionCommand : IRequest<AppResponse<DecanalResolution>>
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
