using InspectionVisits.Application.Commands.AddInspectionVist;
using InspectionVisits.Application.Commands.AddVaiolations;
using InspectionVisits.Application.Commands.UpdateInspectionVisiStatus;
using InspectionVisits.Application.DTo;
using InspectionVisits.Application.Queries.GetAllEntityToInsepect;
using InspectionVisits.Application.Queries.GetAllIspectionsVisits;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionVisits.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectVisitController : ControllerBase
    {
        private IMediator mediator;

        public InspectVisitController(IMediator _mediator)
        {
            mediator= _mediator;
            
        }

        [HttpPost("addinspection-visit")]
        public async Task<ActionResult<ApiResponse<bool>>> AddInspectionVisit(AddInspectionVisitCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
        [HttpPost("add-vaiolations")]
        public async Task<ActionResult<ApiResponse<bool>>> AddVaiolations(AddVaiolationsCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("getall-ispections-visits")]
        public async Task<ActionResult<ApiResponse<IEnumerable<InspectionVisitDto>>>> GetAllIspectionsVisits(InspectVisitDToCriteria command)
        {
            var result = await mediator.Send(new GetAllIspectionsVisitsQuery {  criteria=command});

            return Ok(result);
        }

        [HttpPost("update-inspection-viststatus")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateInspectionVistStatus(UpdateInspectionVisitStausCommand command)
        {
            var result = await mediator.Send(command); ;

            return Ok(result);
        }
    }
}
