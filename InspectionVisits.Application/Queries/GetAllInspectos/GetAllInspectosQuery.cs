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

namespace InspectionVisits.Application.Queries.GetAllInspectos
{
    public record GetAllInspectosQuery() : IRequest<ApiResponse<IEnumerable<InspectorDto>>>;

    public class GetAllInspectosQueryHandler : IRequestHandler<GetAllInspectosQuery, ApiResponse<IEnumerable<InspectorDto>>>
    {
        private readonly IMapper mapper;
        private readonly IEntityToInspectRepository entityToInspectRepository;

        public GetAllInspectosQueryHandler(IMapper _mapper, IEntityToInspectRepository _entityToInspectRepository)
        {
            mapper = _mapper;
            entityToInspectRepository = _entityToInspectRepository;
        }

        public async Task<ApiResponse<IEnumerable<InspectorDto>>> Handle(GetAllInspectosQuery request, CancellationToken cancellationToken)
        {



            var result = await entityToInspectRepository.GetAllInspectors(0, int.MaxValue);

            if (!result.Any())

                return new ApiResponse<IEnumerable<InspectorDto>>(null, 0);


            return new ApiResponse<IEnumerable<InspectorDto>>(mapper.Map<IEnumerable<InspectorDto>>(result), result.Count());



        }
    }

}
