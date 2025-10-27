using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InspectionVisits.Domain.Enums;

namespace InspectionVisits.Application.DTo
{
    public class InspectionVisitDto
    {
        public int Id { get; set; }
        public string EntityToInspe { get; set; }
        public int EntityToInspectId { get; set; }
        public string InspectorName { get; set; }
        public int InspectorId { get; set; }

        public DateTime ScheduledAt { get; set; }
        public string Starusstring { get; set; }
        public Status Status { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }
        public string Notes { get; set; }

        public string? category { get; set; }
    }
}
