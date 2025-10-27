using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Application.Commands.AddVaiolations
{
    public class AddVaiolationsCommand : IRequest<ApiResponse<bool>>
    {
        public int InspectionVisitId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; }
        public int Score { get; set; }
    }

    public class AddVaiolationsCommandHandler : IRequestHandler<AddVaiolationsCommand, ApiResponse<bool>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;

        public AddVaiolationsCommandHandler(IEntityToInspectRepository _entityToInspectRepository)
        {
            entityToInspectRepository = _entityToInspectRepository;

        }
        public async Task<ApiResponse<bool>> Handle(AddVaiolationsCommand request, CancellationToken cancellationToken)
        {
            var entityToInspect = await entityToInspectRepository.GetInspectionVistById(request.InspectionVisitId);

            if (entityToInspect is null)

                return new ApiResponse<bool>(false);

            entityToInspect.AddViolations(new List<Violation> {
                new Violation {
                    Code= request.Code,
                    Description= request.Description,
                    Severity= request.Severity,
                    InspectionVisitId= request.InspectionVisitId,
                }

            });
            entityToInspectRepository.SaveChanges();
            return new ApiResponse<bool>(true);


        }

    }
}
