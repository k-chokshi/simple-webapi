using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}