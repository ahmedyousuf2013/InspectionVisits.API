using AutoMapper;
using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect
{
    public class CreatOrUpdateEntityToInspectCommand : IRequest<ApiResponse<bool>>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }

    }

    public class CreatOrUpdateEntityToInspectCommandHandler : IRequestHandler<CreatOrUpdateEntityToInspectCommand, ApiResponse<bool>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;

        public IMapper mapper { get; }

        public CreatOrUpdateEntityToInspectCommandHandler(IEntityToInspectRepository _entityToInspectRepository, IMapper _mapper)
        {
            entityToInspectRepository = _entityToInspectRepository;
            mapper = _mapper;


        }
        public async Task<ApiResponse<bool>> Handle(CreatOrUpdateEntityToInspectCommand request, CancellationToken cancellationToken)
        {


            if (!request.Id.HasValue)
            {
                var entityToinsepect = mapper.Map<EntityToInspect>(request);
                entityToInspectRepository.Add(entityToinsepect);
            }
            else
            {
                var entityToinsepect = entityToInspectRepository.FindOne(x => x.Id == request.Id);

                if (entityToinsepect is null)
                    return new ApiResponse<bool>(false);

                entityToinsepect.Updae(request.Name, request.Address, request.Category);
                entityToInspectRepository.Update(entityToinsepect);
            }


            return new ApiResponse<bool>(true);
        }
    }
}
