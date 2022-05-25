using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ActQuery : IActQuery
    {
        public readonly PlannerDbContext dbContext;
        public ActQuery(PlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<ActModel> GetActs()
        {
            return dbContext.Acts;
        }
        public IQueryable<ActModel> GetActsByUserId(string id)
        {
            return dbContext.Acts.Where(a => a.UserId == id);
        }
        public IQueryable<ActModel> GetActsByUserName(string name)
        {
            return dbContext.Acts.Include(a => a.User).Where(a => a.User.UserName == name);
        }
    }
}
