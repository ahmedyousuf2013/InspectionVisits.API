using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Domain.Aggregate.InspectionAggregate
{
    public class Inspector : BaseEntity
    {
        public Inspector() { }
        
        public Inspector( int id,string fullName ,string email , string phone ,string role) 
        {
            this.Id = id;
            this.FullName = fullName;
            this.Email = email; 
            this.Phone = phone;
            this.Role = role;
            
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } // Admin or Inspector
    }
}
