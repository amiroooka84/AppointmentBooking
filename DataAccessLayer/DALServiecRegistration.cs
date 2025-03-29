using DataAccessLayer.DataBase;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.RepositoryAppointment;
using DataAccessLayer.Repositories.RepositoryCustomer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer
{
    public static class DALServiecRegistration
    {
        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<db>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=AppointmentBooking;Integrated Security=True;TrustServerCertificate=True");
            }, ServiceLifetime.Transient);
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IRepositoryAppointment, RepositoryAppointment>();
            services.AddScoped<IRepositoryCustomer, RepositoryCustomer>();
            return services;
        }
    }
}
