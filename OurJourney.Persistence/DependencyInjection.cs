using Microsoft.Extensions.DependencyInjection;
using OurJourney.Application.Common.Interface;
using OurJourney.Persistence.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurJourney.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new OutJourneyDataBase(connectionString));
            return services;
        }
    }
}
