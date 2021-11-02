using System;
using api.data.Context;
using api.data.Implementations;
using api.data.Repository;
using api.domain.Interfaces;
using api.domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace api.crosscutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            }

        }
    }
}
