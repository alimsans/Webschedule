using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebSchedule.Infrastructure.Implementations;

namespace WebSchedule.DesignTimeTooling
{
    public class DataProviderDesignTimeFactory : IDesignTimeDbContextFactory<DataProvider>
    {
        public DataProvider CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=WebSchedule");

            return new DataProvider(optionsBuilder.Options);
        }
    }
}
