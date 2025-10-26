using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using InspectionVisits.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;
using InspectionVisits.Application.Extensions;

namespace InspectionVisits.Repository
{
    public class EntityToInspectRepository : Repository<EntityToInspect>, IEntityToInspectRepository
    {
        public EntityToInspectRepository(AppDbContext context ) :base(context)
        {
            
        }

       public async Task<IEnumerable<EntityToInspect>> GetAll(int pageIndex, int PageSize)
        {

            var reuslt = this.dbContext.EntitiesToInspect
                .OrderByDescending(x=>x.Id)
                .Skip(PageSize * pageIndex)
                .Take(PageSize)
                .ToList();
           
           return reuslt;
        }

        public async Task<IEnumerable<InspectionVisitDto>> GetAllInspectVisits(InspectVisitDToCriteria criteria)
        {

            var query = (from visits in this.dbContext.InspectionVisits
                         join entity in this.dbContext.EntitiesToInspect
                         on visits.EntityToInspectId equals entity.Id

                         select new InspectionVisitDto
                         {
                             Status = visits.Status,
                             EntityToInspe = visits.EntityToInspect.Name,
                             InspectorName = visits.Inspector.FullName,
                             Notes = visits.Notes,
                             ScheduledAt = visits.ScheduledAt,
                             Score = visits.Score,
                             EntityToInspectId = visits.EntityToInspect.Id,
                             InspectorId = visits.Inspector.Id,
                             category=entity.Category
                         }).AsQueryable();


            query = query.WhereIf(criteria.from.HasValue, x => x.ScheduledAt >= criteria.from.Value);
            query = query.WhereIf(criteria.to.HasValue, x => x.ScheduledAt <= criteria.to.Value);
            query = query.WhereIf(criteria.inspectorId.HasValue, x => x.EntityToInspectId == criteria.inspectorId.Value);
            query = query.WhereIf(!string.IsNullOrEmpty(criteria.category), x => criteria.category.Contains( x.category));

            return query.AsEnumerable();
        }

        public async Task<IEnumerable<Inspector>> GetAllInspectors(int pageIndex, int PageSize)
        {
            var reuslt = this.dbContext.Inspectors
                .OrderByDescending(x => x.Id)
                .Skip(PageSize * pageIndex)
                .Take(PageSize)
                .AsEnumerable();

            return reuslt;
        }
        public async Task<InspectionVisit> GetInspectionVisit(int entityToInspectId , int inspectorId)
        {
            var reuslt = this.dbContext.InspectionVisits
         .Where(x => x.EntityToInspectId == entityToInspectId && x.InspectorId == inspectorId).FirstOrDefault();

            return reuslt;
        }

    }
}
