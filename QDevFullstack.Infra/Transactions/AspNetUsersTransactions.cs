
using Microsoft.AspNetCore.Identity;

namespace QDevFullstack.Infra.Transactions
{
    public interface IAspNetUsersTransactions
    {
        Task<IdentityUser?> GetByEmail(string email);
        Task<IdentityUser?> GetById(string id);
    }

    public class AspNetUsersTransactions(UserManager<IdentityUser> userManager) : IAspNetUsersTransactions
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<IdentityUser?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser?> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }

}