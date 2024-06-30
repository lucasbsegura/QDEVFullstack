using Microsoft.Extensions.Configuration;

namespace QDevFullstack.Test.Helpers
{
    public static class FakeConfigurationBuilder
    {
        public static IConfigurationRoot Build()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                { "ConnectionStrings:DefaultDb", "Server=localhost;Database=QDevFullstackDb;Persist Security Info=True;User ID=SA;Password=R00t3d??;TrustServerCertificate=true;" },
            };
            return new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }
    }
}
