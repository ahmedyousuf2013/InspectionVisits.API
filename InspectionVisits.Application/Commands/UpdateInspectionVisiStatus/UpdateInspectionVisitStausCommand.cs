using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Application.Commands.UpdateInspectionVisiStatus
{
    public record class UpdateInspectionVisitStausCommand : IRequest<ApiResponse<bool>>
    {
        public int InsoectionVisitId { get; set; }
        public Status Status { get; set; }
    }
    public class UpdateInspectionVisitStausCommandHandler : IRequestHandler<UpdateInspectionVisitStausCommand, ApiResponse<bool>>
    {
        private IEntityToInspectRepository entityToInspectRepository;

        public UpdateInspectionVisitStausCommandHandler(IEntityToInspectRepository  _entityToInspectRepository)
        {
            entityToInspectRepository= _entityToInspectRepository;
        }
        public async Task<ApiResponse<bool>> Handle(UpdateInspectionVisitStausCommand request, CancellationToken cancellationToken)
        {
         var result=    await  entityToInspectRepository.GetInspectionVistById(request.InsoectionVisitId);
            if (result == null)
            {
                return new ApiResponse<bool>(false);

            }
            else 
            {
                result.Status =request.Status;
                entityToInspectRepository.SaveChanges();
            
            }
            return  new ApiResponse<bool>(true);
        }
    }

}
