using AutoMapper;
using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Queries.GetAllEntityToInsepect
{
    public record GetAllEntityToInsepectQuery(int pageIndex, int pagesize) : IRequest<ApiResponse<IEnumerable<EntityToInspectDto>>>;


    public class GetAllEntityToInsepectQueryHandler : IRequestHandler<GetAllEntityToInsepectQuery, ApiResponse<IEnumerable<EntityToInspectDto>>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;
        private readonly IMapper mapper;

        public GetAllEntityToInsepectQueryHandler(IEntityToInspectRepository _entityToInspectRepository, IMapper _mapper)
        {
            entityToInspectRepository = _entityToInspectRepository;
            mapper = _mapper;
        }
        public async Task<ApiResponse<IEnumerable<EntityToInspectDto>>> Handle(GetAllEntityToInsepectQuery request, CancellationToken cancellationToken)
        {
            var result = await entityToInspectRepository.GetAll(request.pageIndex, request.pagesize);

            if (!result.Any())

                return new ApiResponse<IEnumerable<EntityToInspectDto>>(null, 0);

            return new ApiResponse<IEnumerable<EntityToInspectDto>>(mapper.Map<IEnumerable<EntityToInspectDto>>(result), 0);
        }
    }
}
