using Autofac;
using Microsoft.Extensions.Configuration;
using WebSchedule.BusinessLayer.Services.Implementations;
using WebSchedule.BusinessLayer.Services.Interfaces;
using WebSchedule.DependenciesResolver.Helpers;
using WebSchedule.Infrastructure.Implementations;
using WebSchedule.Infrastructure.Interfaces;

namespace WebSchedule.DependenciesResolver
{
    public static class Bootstrapper
    {
        public static void Initialize(ContainerBuilder builder, IConfiguration config)
        {
            InitializeInfrastructure(builder, config);
            InitializeBusinessLayer(builder, config);

            builder.RegisterInstance(MapperDto.Mapper);
        }

        private static void InitializeInfrastructure(ContainerBuilder builder, IConfiguration config)
        {
            builder.RegisterInstance
                (new AppSettingsConnectionStringProvider
                {
                    ConnectionString = config.GetConnectionString("Default")
                })
                .As<IConnectionStringProvider>()
                .SingleInstance();

            builder.RegisterType<DataProvider>()
                .As<IDataProvider>()
                .InstancePerDependency();
        }
        
        private static void InitializeBusinessLayer(ContainerBuilder builder, IConfiguration config)
        {
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerDependency();
        }        
    }
}
