using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Domain.Aggregate.InspectionAggregate
{
    public class EntityToInspect : BaseEntity
    {
     
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }

        public virtual List<InspectionVisit> InspectionVisits { get; set; }=new List<InspectionVisit>();

        public void Update(string name, string address, string Category)
        {
            this.Name = name;
            this.Address = address;
            this.Category = Category;
        
        }

        public void AddInspectResult(InspectionVisit inspectionVisit) 
        {
           this.InspectionVisits.Add(inspectionVisit);


        
        }
    }

   
}
