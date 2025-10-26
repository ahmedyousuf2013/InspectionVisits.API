using FluentValidation;
using InspectionVisits.Application.Behaviors;
using InspectionVisits.Application.Commands.CreatOrUpdateEntityToInspect;
using InspectionVisits.Domain.Contracts;
using InspectionVisits.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));

            });

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.RegisterServicesFromAssembly(typeof(CreatOrUpdateEntityToInspectCommand).Assembly);
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEntityToInspectRepository,EntityToInspectRepository>();

            services.AddSingleton<IValidator<CreatOrUpdateEntityToInspectCommand>, CreatOrUpdateEntityToInspectCommandValidator>();
            return services;
        }
    }

}
