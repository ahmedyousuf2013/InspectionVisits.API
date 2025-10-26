using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect
{
    public class CreatOrUpdateEntityToInspectCommandValidator : AbstractValidator<CreatOrUpdateEntityToInspectCommand>
    {
        public CreatOrUpdateEntityToInspectCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Address).NotEmpty().NotNull();
            RuleFor(x => x.Category).NotEmpty().NotNull();

        }
    }
}
