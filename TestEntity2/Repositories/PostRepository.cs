using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.contexts;
using TestEntity2.Models;

namespace TestEntity2.Repositories
{
    public class PostRepository
    {

        private readonly testentityContext _context;

        public PostRepository(testentityContext context)
        {
            this._context = context;
        }

        public List<Posts> GetAll()
        {
            return this._context.Posts.OrderByDescending(p => p.Id).ToList();
        }

        public Posts Get(int id)
        {
            return this._context.Posts.Find(id);
        }

        public int Create(Posts post)
        {
            this._context.Add(post);
            return this._context.SaveChanges();
        }

        public int Delete(Posts post)
        {
            this._context.Remove(post);
            return this._context.SaveChanges();
        }

        public int Update(Posts post)
        {
            this._context.Update(post);
            return this._context.SaveChanges();
        }
    }
}
