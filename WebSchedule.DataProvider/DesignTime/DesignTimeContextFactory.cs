using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebSchedule.Infrastructure.Implementations;

namespace WebSchedule.Infrastructure.DesignTime
{
    
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class DesignTimeContextFactory: IDesignTimeDbContextFactory<DataProvider>
    {
        public DataProvider CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataProvider>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WebSchedule;Trusted_Connection=True;");

            return new DataProvider(optionsBuilder.Options);
        }
    }
}
