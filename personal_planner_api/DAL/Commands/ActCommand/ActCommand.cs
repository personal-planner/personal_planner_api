using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class ActCommand : IActCommand
    {
        private  PlannerDbContext context { get; }

        public ActCommand(PlannerDbContext context)
        {
            this.context = context;
        }

        public void CreateAct(ActModel model)
        {
           context.Acts.Add(model);
           context.SaveChanges();
        }
    }
}
