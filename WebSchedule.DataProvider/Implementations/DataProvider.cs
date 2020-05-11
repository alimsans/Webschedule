using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSchedule.Infrastructure.Entities;
using WebSchedule.Infrastructure.Interfaces;

namespace WebSchedule.Infrastructure.Implementations
{
    public class DataProvider : DbContext, IDataProvider
    {
        public override void Dispose()
        {
            Console.WriteLine("Context Disposed");
            base.Dispose();
        }

        #region Dependecies

        private readonly string _connectionString;

        #endregion

        #region Tables

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Role> Roles { get; set; }

        #endregion

        #region .ctor

        public DataProvider(IConnectionStringProvider connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

        internal DataProvider(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Jwt)
                .IsUnique();
        }

        #endregion

        #region Public Methods

        public new IQueryable<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await base.AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await base.AddRangeAsync(entities);
        }

        public new void Remove<T>(T entity) where T : class
        {
            base.Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            base.RemoveRange(entities);
        }

        public async Task SaveAsync()
        {
            await base.SaveChangesAsync();
        }

        #endregion

        #region Private Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        #endregion
    }
}
