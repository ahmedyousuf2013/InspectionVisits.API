using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Queries.GetAllIspectionsVisits
{
    public class GetAllIspectionsVisitsQuery : IRequest<ApiResponse<IEnumerable< InspectionVisitDto>>>
    {
        public InspectVisitDToCriteria criteria { get; set; }
    }

    public class GetAllIspectionsVisitsQueryHandler : IRequestHandler<GetAllIspectionsVisitsQuery, ApiResponse<IEnumerable<InspectionVisitDto>>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;

        public GetAllIspectionsVisitsQueryHandler(IEntityToInspectRepository _entityToInspectRepository)
        {
            entityToInspectRepository= _entityToInspectRepository;
        }

        public async Task<ApiResponse<IEnumerable<InspectionVisitDto>>> Handle(GetAllIspectionsVisitsQuery request, CancellationToken cancellationToken)
        {
          var result=  await entityToInspectRepository.GetAllInspectVisits(request.criteria);



            return new ApiResponse<IEnumerable<InspectionVisitDto>>(result);

        }
    }
}
