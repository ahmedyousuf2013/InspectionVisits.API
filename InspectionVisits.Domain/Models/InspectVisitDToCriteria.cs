using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Application.DTo
{
    public class InspectVisitDToCriteria
    {

        public DateTime? from { get; set; }
        public DateTime? to { get; set; }
        public Status? Status { get; set; }

        public int? inspectorId { get; set; }
        public string? category { get; set; }
 
    }
}
