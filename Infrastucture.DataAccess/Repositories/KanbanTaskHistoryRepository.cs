using DataModel;
using Infrastucture.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.DataAccess.Repositories
{
    public class KanbanTaskHistoryRepository : GenericRepository<KanbanTaskHistory>, IKanbanTaskHistoryRepository
    {
        public KanbanTaskHistoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
