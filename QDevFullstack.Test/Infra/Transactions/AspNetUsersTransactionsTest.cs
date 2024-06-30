

using Microsoft.AspNetCore.Identity;
using Moq;
using QDevFullstack.Infra.Transactions;

namespace QDevFullstack.Test.Infra.Transactions
{
    public class AspNetUsersTransactionsTest
    {
        private readonly string id = "123";
        private readonly string email = "test@email.com";
        private readonly IAspNetUsersTransactions _userTransactions;

        public AspNetUsersTransactionsTest()
        {
            var mockUserStore = new Mock<IUserStore<IdentityUser>>();
            mockUserStore.Setup(x => x.FindByIdAsync("123", CancellationToken.None))
                .ReturnsAsync(new IdentityUser()
                {
                    UserName = email,
                    Email = email,
                    Id = "123"
                });
            var mgr = new UserManager<IdentityUser>(mockUserStore.Object, null, null, null, null, null, null, null, null);
            _userTransactions = new AspNetUsersTransactions(mgr);
        }

        [Fact]
        public async void DeveEncontrarUsuarioPeloId()
        {
            var user = await _userTransactions.GetById(id);
            Assert.True(email == user.Email);
        }
    }
}