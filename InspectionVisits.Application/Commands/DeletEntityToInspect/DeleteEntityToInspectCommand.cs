using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Commands.DeletEntityToInspect
{
    public record DeleteEntityToInspectCommand(int entityToinspectId) : IRequest<ApiResponse<bool>>;


    public class DeleteEntityToInspectCommandHandler : IRequestHandler<DeleteEntityToInspectCommand, ApiResponse<bool>>
    {
        private readonly IEntityToInspectRepository entityToInspectRepository;

        public DeleteEntityToInspectCommandHandler(IEntityToInspectRepository _entityToInspectRepository)
        {
            entityToInspectRepository = _entityToInspectRepository;

        }
        public async Task<ApiResponse<bool>> Handle(DeleteEntityToInspectCommand request, CancellationToken cancellationToken)
        {
            var result = entityToInspectRepository.FindOne(x => x.Id == request.entityToinspectId);


            if (result is null)

                return new ApiResponse<bool>(false);

            entityToInspectRepository.Delete(result);

            return new ApiResponse<bool>(true);
        }
    }

}
