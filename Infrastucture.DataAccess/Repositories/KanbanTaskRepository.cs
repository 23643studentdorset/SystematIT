using DataModel;
using Infrastucture.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.DataAccess.Repositories
{
    public class KanbanTaskRepository: GenericRepository<KanbanTask>, IKanbanTaskRepository
    {
        public KanbanTaskRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
