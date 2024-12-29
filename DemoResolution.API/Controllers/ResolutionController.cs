using DemoResolution.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoResolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResolutionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResolutionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResolution([FromBody] CreateResolutionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
