using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Domain.SeedData
{
    public static class InitialSeeds
    {
        public static void InitialSeeding(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Inspector>().HasData(new Inspector(1,"Inspector 1","Inspetor1@gamil.com","01099999999","admin"));
            modelBuilder.Entity<Inspector>().HasData(new Inspector(2,"Inspector 2", "Inspetor2@gamil.com", "01099999999", "inspector"));
        }
    }
}
