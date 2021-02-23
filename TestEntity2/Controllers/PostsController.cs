using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TestEntity2.Models;
using TestEntity2.Repositories;


namespace TestEntity2.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostRepository _repo;
        private readonly CategoryRepository _repoCategory;

   
        public PostsController(PostRepository repo, CategoryRepository repoCategory)
        {
            _repo = repo;
            _repoCategory = repoCategory;
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
            ViewBag.Categories = this._repoCategory.GetAll();
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
                post.CategoryId = Convert.ToInt32(collection["Category"]);
                post.Description = "toto";
                post.AuthorId = 1;

                if (collection["Publish.Value"].Contains("true"))
                {
                    post.Publish = true;
                }
                else
                {
                    post.Publish = false;
                }
                int isSave = this._repo.Create(post);
                TempData["isSave"] = isSave;
                TempData["message"] = "L'article a bien été sauvegardé";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Categories = this._repoCategory.GetAll();
                TempData["isSave"] = 0;
                TempData["message"] = "Il y a eu une erreur sur la sauvegarde de l'article";
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public ActionResult Edit(int id)
        {
            Posts post = this._repo.Get(id);
            ViewBag.Categories = this._repoCategory.GetAll();
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
                post.CategoryId = Convert.ToInt32(collection["Category"]);
                if (collection["Publish.Value"].Contains("true"))
                {
                    post.Publish = true;
                }
                else
                {
                    post.Publish = false;
                }
                int isUpdate = this._repo.Update(post);
                TempData["isSave"] = isUpdate;
                TempData["message"] = "L'article a bien été édité";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Publish/5/isPublish
        public ActionResult Publish(int id, bool publish)
        {
            try
            {
                Posts post = this._repo.Get(id);
                post.Publish = publish;
                int isUpdate = this._repo.Update(post);
                TempData["isSave"] = isUpdate;
                TempData["message"] = "L'article a bien été publié";
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
                int isDelete = this._repo.Delete(post);
                TempData["isSave"] = isDelete;
                TempData["message"] = "L'article a bien été supprimé";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
