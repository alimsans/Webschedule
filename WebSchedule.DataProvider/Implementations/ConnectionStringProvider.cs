using WebSchedule.DataProvider.Interfaces;

namespace WebSchedule.DataProvider.Implementations
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string ConnectionString { get; set; }
    }
}
