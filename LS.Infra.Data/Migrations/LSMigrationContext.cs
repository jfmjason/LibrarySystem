using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace LS.Infra.Data.migration
{
    public sealed class LSMigrationContext : IDesignTimeDbContextFactory<LSDbContext>
    {
        public LSDbContext CreateDbContext(string[] args)
        {

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            var builder = new DbContextOptionsBuilder<LSDbContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            builder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                 x => x.MigrationsHistoryTable("__LSMigrationsHistory")
                 
                );

            return new LSDbContext(builder.Options);
        }
    }
}
