using InspectionVisits.Application.DTo;
using InspectionVisits.Application.Queries.GetAllEntityToInsepect;
using InspectionVisits.Application.Queries.GetAllInspectos;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionVisits.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorsController : ControllerBase
    {
        private readonly IMediator mediator;

        public InspectorsController(IMediator _mediator)
        {
            mediator= _mediator;
        }


        [HttpPost("get-all-inspectosquery")]
        public async Task<ActionResult<ApiResponse<IEnumerable<InspectorDto>>>> GetAllInspectosQuery(GetAllInspectosQuery command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}

