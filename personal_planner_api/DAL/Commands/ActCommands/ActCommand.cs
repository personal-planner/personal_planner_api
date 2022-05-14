using DAL.EntityFramework;
using DAL.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Commands.ActCommands
{
    class ActCommand
    {
        private  PlannerDbContext context { get; }

        public ActCommand(PlannerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAct(ActModel model)
        {
           await context.Acts.AddAsync(model);
           await context.SaveChangesAsync();
        }
    }
}
