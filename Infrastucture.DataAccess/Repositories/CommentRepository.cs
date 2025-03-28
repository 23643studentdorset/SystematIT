using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.DataAccess.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly DbSet<Comment> _entities;

        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _entities = context.Set<Comment>();
        }

        public async Task<Comment> GetWithTaskDetails(int id)
        {
            return await _entities.Include(x => x.KanbanTask).FirstOrDefaultAsync(y => y.CommentId == id);
        }
    }
}
