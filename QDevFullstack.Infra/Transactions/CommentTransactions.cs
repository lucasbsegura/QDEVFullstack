using Microsoft.EntityFrameworkCore;
using QDevFullstack.Infra.Database;
using QDevFullstack.Infra.Models;

namespace QDevFullstack.Infra.Transactions
{
    public interface ICommentTransactions
    {
        Task<List<Comment>> Get();
        Task<Comment?> GetById(int id);
        Task<int> Create(Comment comment);
        Task<bool> Update(Comment comment);
        Task<bool> Remove(int id);
    }

    public class CommentTransactions(ApplicationDbContext context) : ICommentTransactions
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Comment>> Get()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return comment;
        }

        public async Task<int> Create(Comment comment)
        {
            comment.CreatedDate = DateTime.Now;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<bool> Remove(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Comment comment)
        {
            comment.UpdatedDate = DateTime.Now;
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(comment.Id))
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

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
