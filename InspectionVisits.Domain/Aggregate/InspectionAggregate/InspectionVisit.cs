using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Domain.Aggregate.InspectionAggregate
{
    public class InspectionVisit : BaseEntity
    {
        public int EntityToInspectId { get; set; }
        [ForeignKey("EntityToInspectId")]
        public virtual EntityToInspect EntityToInspect { get; set; }
        public int InspectorId { get; set; }
        [ForeignKey("InspectorId")]
        public virtual Inspector Inspector { get; set; }
        public DateTime ScheduledAt { get; set; }
        public Status Status { get; set; }

        [Range(0,100)]
        public int Score { get; set; }
        public string Notes { get; set; }


        public List<Violation> Violations { get; set; } = new List<Violation>();
        public void UpdateStatus(Status status) 
        {
            this.Status = status;
        
        }

        public void AddViolations(List<Violation> violations)
        {
            this.Violations.AddRange(violations);

        }


    }
}
