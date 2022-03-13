using MealOrdering.Server.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MealOrdering.Server.Data
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MealOrderingDbContext>
    {
        public MealOrderingDbContext CreateDbContext(string[] args)
        {
            string connectionString = "User ID=postgres;password=admin;Host=localhost;Port=5432;Database=mealordering;SearchPath=public";
            var builder = new DbContextOptionsBuilder<MealOrderingDbContext>();
            builder.UseNpgsql(connectionString);

            return new MealOrderingDbContext(builder.Options);
        }
    }
}