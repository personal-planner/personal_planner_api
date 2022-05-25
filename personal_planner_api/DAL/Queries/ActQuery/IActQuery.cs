using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public interface IActQuery
    {
        public IQueryable<ActModel> GetActs();
        public IQueryable<ActModel> GetActsByUserId(string id);
        public IQueryable<ActModel> GetActsByUserName(string name);
    }
}
