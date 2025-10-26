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

namespace InspectionVisits.Application.Queries.GetEntityToInsepectById
{
    public record GetEntityToInsepectByIdQuery(int EntityToInsepectId) : IRequest<ApiResponse<EntityToInspectDto>>;

    public class GetEntityToInsepectByIdQueryHandler : IRequestHandler<GetEntityToInsepectByIdQuery, ApiResponse<EntityToInspectDto>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;
        private readonly IMapper mapper;

        public GetEntityToInsepectByIdQueryHandler(IEntityToInspectRepository _entityToInspectRepository, IMapper _mapper)
        {
            entityToInspectRepository = _entityToInspectRepository;
            mapper = _mapper;
        }
        public async Task<ApiResponse<EntityToInspectDto>> Handle(GetEntityToInsepectByIdQuery request, CancellationToken cancellationToken)
        {

            var result = entityToInspectRepository.FindOne(x => x.Id == request.EntityToInsepectId);
            if (result is not null)

                return new ApiResponse<EntityToInspectDto>(mapper.Map<EntityToInspectDto>(result));

            return new ApiResponse<EntityToInspectDto>(new List<string>(), "No Data");

        }
    }

}
