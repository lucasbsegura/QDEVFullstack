using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QDevFullstack.Infra.Database;
using QDevFullstack.Infra.Transactions;

namespace QDevFullstack.Infra
{

    public class ServicesRegistrator
    {
        public static void Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IAspNetUsersTransactions, AspNetUsersTransactions>();

        }
    }

}