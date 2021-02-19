using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.Models;
using TestEntity2.Repositories;

namespace TestEntity2.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostRepository _repo;

        public PostsController(PostRepository repo)
        {
            _repo = repo;
        }

        // GET: PostsController
        public ActionResult Index()
        {
            ViewBag.Posts = this._repo.GetAll();
            return View();
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Post = this._repo.Get(id);
            return View();
        }

        // GET: PostsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Posts post = new Posts();
                post.Title = collection["Title"];
                post.Content = collection["Content"];
                if (collection["Publish.Value"].Contains("true"))
                {
                    post.Publish = true;
                }
                else
                {
                    post.Publish = false;
                }
                this._repo.Create(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public ActionResult Edit(int id)
        {
            Posts post = this._repo.Get(id);
            return View(post);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Posts post = this._repo.Get(id);
                post.Title = collection["Title"];
                post.Content = collection["Content"];
                if (collection["Publish.Value"].Contains("true"))
                {
                    post.Publish = true;
                }
                else
                {
                    post.Publish = false;
                }
                this._repo.Update(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: PostsController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Posts post = this._repo.Get(id);
                this._repo.Delete(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
