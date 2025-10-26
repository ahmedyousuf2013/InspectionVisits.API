using InspectionVisits.Application.Commands.Auth;
using InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect;
using InspectionVisits.Application.DTo;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionVisits.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator _mediator)
        {
            mediator= _mediator;
        }
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResult>>> Login(LoginCommand command)
        {
            var result = await mediator.Send(command);


            return Ok(result);
        }

    }
}
