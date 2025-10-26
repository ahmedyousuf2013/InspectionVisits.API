using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Domain.Contracts
{
    public interface IEntityToInspectRepository : IRepository<EntityToInspect>
    {
        public Task<IEnumerable<InspectionVisitDto>> GetAllInspectVisits(InspectVisitDToCriteria criteria);

        public Task<IEnumerable<EntityToInspect>> GetAll(int pageIndex, int PageSize);

        public Task<IEnumerable<Inspector>> GetAllInspectors(int pageIndex, int PageSize);
        public Task<InspectionVisit> GetInspectionVisit(int entityToInspectId, int inspectorId);




    }
}
