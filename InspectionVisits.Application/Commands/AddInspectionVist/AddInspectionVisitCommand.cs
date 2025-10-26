using AutoMapper;
using InspectionVisits.Application.DTo;
using InspectionVisits.Domain;
using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Application.Commands.AddInspectionVist
{
    public record AddInspectionVisitCommand(int EntityToInspectId, int InspectorId, DateTime ScheduledAt, Status Status, int Score, string Notes) : IRequest<ApiResponse<bool>>;

    public class AddInspectionVisitCommandHandler : IRequestHandler<AddInspectionVisitCommand, ApiResponse<bool>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;
        private readonly IMapper mapper;

        public AddInspectionVisitCommandHandler(IEntityToInspectRepository _entityToInspectRepository, IMapper _mapper)
        {
            entityToInspectRepository = _entityToInspectRepository;
            mapper = _mapper;

        }
        public async Task<ApiResponse<bool>> Handle(AddInspectionVisitCommand request, CancellationToken cancellationToken)
        {
            var entitytoInspect = entityToInspectRepository.FindOne(x => x.Id == request.EntityToInspectId, findOptions: new FindOptions { IsAsNoTracking = false });


            if (entitytoInspect is null)
                return new ApiResponse<bool>(false);

            var inspectvisit = await entityToInspectRepository.GetInspectionVisit(request.EntityToInspectId, request.InspectorId);

            if (inspectvisit is null)
            {
                entitytoInspect.AddInspectResult(mapper.Map<InspectionVisit>(request));
            }
            else
            {
                inspectvisit.UpdateStatus(request.Status);

            }

            entityToInspectRepository.SaveChanges();
            return new ApiResponse<bool>(true);
        }
    }
}
