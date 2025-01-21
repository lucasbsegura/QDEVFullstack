using Microsoft.EntityFrameworkCore;
using QDevFullstack.Infra.Database;
using QDevFullstack.Infra.Models;

namespace QDevFullstack.Infra.Transactions
{
    public interface IPostTransactions
    {
        Task<List<Post>> Get();
        Task<Post?> GetById(int id);
        Task<int> Create(Post post);
        Task<bool> Update(Post post);
        Task<bool> Remove(int id);
    }

    public class PostTransactions(ApplicationDbContext context) : IPostTransactions
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> Create(Post post)
        {
            post.CreatedDate = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<List<Post>> Get()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> GetById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post;
        }

        public async Task<bool> Remove(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Post post)
        {
            post.UpdatedDate = DateTime.Now;
            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(post.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
