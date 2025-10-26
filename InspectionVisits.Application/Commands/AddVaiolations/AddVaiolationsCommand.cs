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

namespace InspectionVisits.Application.Commands.AddVaiolations
{
    public class AddVaiolationsCommand : IRequest<ApiResponse<bool>>
    {
        public int InspectiorId { get; set; }
        public int EntityToInspectId { get; set; }

        public List<Violation> Violations { get; set; }
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
            var entityToInspect = await entityToInspectRepository.GetInspectionVisit(request.EntityToInspectId, request.InspectiorId);

            if (entityToInspect is null)

                return new ApiResponse<bool>(false);

            entityToInspect.AddViolations(request.Violations);

            entityToInspectRepository.SaveChanges();
            return new ApiResponse<bool>(true);


        }

    }
}
