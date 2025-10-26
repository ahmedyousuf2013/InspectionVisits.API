using AutoMapper;
using InspectionVisits.Application.Commands.AddInspectionVist;
using InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect;
using InspectionVisits.Application.DTo;
using InspectionVisits.Domain.Aggregate.InspectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<EntityToInspect, CreatOrUpdateEntityToInspectCommand>().ReverseMap();

            CreateMap<EntityToInspect, EntityToInspectDto>().ReverseMap();

            CreateMap<InspectorDto, Inspector>().ReverseMap();

            CreateMap<AddInspectionVisitCommand, InspectionVisit>().ReverseMap();
        }
    }
}
