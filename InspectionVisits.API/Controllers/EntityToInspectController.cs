using InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect;
using InspectionVisits.Application.Commands.DeletEntityToInspect;
using InspectionVisits.Application.DTo;
using InspectionVisits.Application.Queries.GetAllEntityToInsepect;
using InspectionVisits.Application.Queries.GetEntityToInsepectById;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionVisits.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityToInspectController : ControllerBase
    {
        private readonly IMediator mediator;

        public EntityToInspectController(IMediator _mediator)
        {
            mediator= _mediator;
            
        }


        [HttpPost("create-orupdate-entitytoinspect")]
        public  async Task< ActionResult<ApiResponse<bool>>>CreateOrUpdate(CreatOrUpdateEntityToInspectCommand command )
        {
          var result=  await mediator.Send(command);


            return Ok(result);
        }

        [HttpGet("get-entitytoinsepect-byId")]
        public async Task<ActionResult<ApiResponse<bool>>> GetEntityToInsepectById([FromQuery] GetEntityToInsepectByIdQuery command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("delete-entityto-inspect")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteEntityToInspect([FromQuery] DeleteEntityToInspectCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("getall-entityto-insepectquery")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EntityToInspectDto>>>> GetAllEntityToInsepectQuery( GetAllEntityToInsepectQuery command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
