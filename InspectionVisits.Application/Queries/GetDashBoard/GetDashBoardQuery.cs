using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Domain.Models;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Queries.GetDashBoard
{
    public class GetDashBoardQuery:IRequest<ApiResponse<InspectionDashboardDto>>
    {
    }
    class GetDashBoardQueryHandler : IRequestHandler<GetDashBoardQuery, ApiResponse<InspectionDashboardDto>>
    {
        private IEntityToInspectRepository entityToInspectRepository;

        public GetDashBoardQueryHandler(IEntityToInspectRepository  _entityToInspectRepository)
        {
            entityToInspectRepository = _entityToInspectRepository;
        }
        public async Task<ApiResponse<InspectionDashboardDto>> Handle(GetDashBoardQuery request, CancellationToken cancellationToken)
        {
          var result=   entityToInspectRepository.GetInspectionDashboard();

          return    new ApiResponse<InspectionDashboardDto>(result);
        }
    }
}
