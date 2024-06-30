using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QDevFullstack.Infra.Database;

namespace QDevFullstack.Test.Helpers
{
    public class MockDbContext
    {
        public static ApplicationDbContext Build()
        {
            var configurationBuilder = FakeConfigurationBuilder.Build();
            var dbOption = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configurationBuilder.GetConnectionString("DefaultDb"))
                .Options;
            var context = new ApplicationDbContext(dbOption);
            return context;
        }
    }
}