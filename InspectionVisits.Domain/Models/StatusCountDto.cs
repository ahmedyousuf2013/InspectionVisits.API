using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Domain.Models
{
    public class StatusCountDto
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }

    public class InspectionDashboardDto
    {
        public List<StatusCountDto> CountsByStatus { get; set; }
        public double AverageScore { get; set; }
    }
}
