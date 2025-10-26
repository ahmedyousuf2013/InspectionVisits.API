using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Domain.Aggregate.InspectionAggregate
{
    public class Violation :BaseEntity
    {
        public int InspectionVisitId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; } 
    }
}
