﻿using System;
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
            return this._context.Posts.ToList();
        }
    }
}