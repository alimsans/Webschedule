using WebSchedule.Infrastructure.Interfaces;

namespace WebSchedule.Infrastructure.Implementations
{
    public class AppSettingsConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString { get; set; }
    }
}
