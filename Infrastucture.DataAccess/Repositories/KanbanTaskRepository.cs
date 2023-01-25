using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.DataAccess.Repositories
{
    public class KanbanTaskRepository : GenericRepository<KanbanTask>, IKanbanTaskRepository
    { 
       
        public KanbanTaskRepository(ApplicationDbContext context) : base (context)
        {
            
        }

    }
}
