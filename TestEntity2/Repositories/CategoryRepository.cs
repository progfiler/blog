using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.Contexts;
using TestEntity2.Models;

namespace TestEntity2.Repositories
{
    public class CategoryRepository
    {
        private readonly testentityContext _context;

        public CategoryRepository(testentityContext context)
        {
            this._context = context;
        }

        public List<Categories> GetAll()
        {
            return this._context.Categories.OrderByDescending(p => p.Id).ToList();
        }

        public Categories Get(int id)
        {
            return this._context.Categories.Find(id);
        }

        public int Create(Categories category)
        {
            this._context.Add(category);
            return this._context.SaveChanges();
        }

        public int Delete(Categories category)
        {
            this._context.Remove(category);
            return this._context.SaveChanges();
        }

        public int Update(Categories category)
        {
            this._context.Update(category);
            return this._context.SaveChanges();
        }

    }
}
