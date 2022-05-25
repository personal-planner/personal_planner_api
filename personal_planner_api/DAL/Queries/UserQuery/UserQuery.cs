using System.Linq;

namespace DAL
{
    public class UserQuery : IUserQuery
    {
        private PlannerDbContext context;

        public UserQuery(PlannerDbContext context)
        {
            this.context = context;
        }

        public UserModel GetByName(string Name)
        {
            return context.Users.FirstOrDefault(u => u.UserName == Name);
        }
    }
}
