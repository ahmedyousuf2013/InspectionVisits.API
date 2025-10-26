using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using InspectionVisits.Domain.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Repository
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<EntityToInspect> EntitiesToInspect { get; set; }
        public DbSet<InspectionVisit> InspectionVisits { get; set; }
        public DbSet<Violation> Violations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.InitialSeeding();
            base.OnModelCreating(modelBuilder);
        }

    }

}
