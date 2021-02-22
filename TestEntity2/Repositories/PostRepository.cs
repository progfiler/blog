using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.Contexts;
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
            return this._context.Posts
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .ToList();
        }

        public Posts Get(int id)
        {
            return this._context.Posts
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .First();
        }

        public List<Posts> GetPublish()
        {
            return this._context.Posts
                .Where(p => p.Publish == true)
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToList();
        }

        public int Create(Posts post)
        {
            this._context.Add(post);
            return this._context.SaveChanges();
        }

        internal List<Posts> GetFilteredPosts(List<int> category_ids)
        {
            return this._context.Posts
               .Select(p => new Posts{ Id = p.Id, CategoryId = p.CategoryId, Publish = p.Publish })
               .Where(p => category_ids.Contains((int)p.CategoryId))
               .Where(p => p.Publish == true)
               .ToList();
        }

        public int Delete(Posts post)
        {
            this._context.Remove(post);
            return this._context.SaveChanges();
        }

        internal List<Posts> GetFilteredALlPosts()
        {
            return this._context.Posts
              .Select(p => new Posts { Id = p.Id, CategoryId = p.CategoryId, Publish = p.Publish })
              .Where(p => p.Publish == true)
              .ToList();
        }

        public int Update(Posts post)
        {
            this._context.Update(post);
            return this._context.SaveChanges();
        }
    }
}
