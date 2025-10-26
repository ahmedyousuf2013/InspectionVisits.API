using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Domain
{
    public class Enums
    {
        public enum Severity
        {
            Low = 1,
            Medium = 2,
            High = 3
        }
        public enum Status
        {
            Planned = 1,
            InProgress = 2,
            Completed = 3,
            Cancelled = 4

        }
    }
}
