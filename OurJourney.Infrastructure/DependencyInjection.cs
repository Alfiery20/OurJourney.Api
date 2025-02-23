using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OurJourney.Application.Common.Interface;
using OurJourney.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurJourney.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
