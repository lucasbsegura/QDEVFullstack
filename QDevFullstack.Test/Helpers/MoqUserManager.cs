using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace QDevFullstack.Test.Helpers
{
    public class MoqUserManager(IUserStore<IdentityUser> userStore) : UserManager<IdentityUser>(userStore,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<IdentityUser>>().Object,
            new IUserValidator<IdentityUser>[0],
            new IPasswordValidator<IdentityUser>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<IdentityUser>>>().Object)
    {
        public override Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(new IdentityUser { Email = email });
        }    
    }
}