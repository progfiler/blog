using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.Contexts;
using TestEntity2.Models;

namespace TestEntity2.Repositories
{
    public class UserRepostory
    {
        testentityContext _context; 
        
        public UserRepostory(testentityContext context)
        {
            _context = context;
        }
        internal List<Users> getAll()
        {
            return this._context.Users
                    .OrderByDescending(p => p.Id)
                    .ToList();
        }

        public Users Get(int id)
        {
            return this._context.Users.Find(id);
        }

        public int Create(Users user)
        {
            this._context.Add(user);
            return this._context.SaveChanges();
        }
        public int Delete(Users user)
        {
            this._context.Remove(user);
            return this._context.SaveChanges();
        }

        public int Update(Users user)
        {
            this._context.Update(user);
            return this._context.SaveChanges();
        }
    }
}
