using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearningHub.Database.Database
{
    public sealed class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=LearningHub;Integrated Security=true;Connection Timeout=5;";

            var builder = new DbContextOptionsBuilder<DatabaseContext>();

            builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(typeof(DatabaseContextFactory).Assembly.GetName().Name));

            return new DatabaseContext(builder.Options);
        }
    }
}
