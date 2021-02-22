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
    public class CategoriesController : Controller
    {
        private readonly CategoryRepository _repo;

        public CategoriesController(CategoryRepository repo)
        {
            _repo = repo;
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            ViewBag.Categories = this._repo.GetAll();
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Categories category = new Categories();
                category.Title = collection["Title"];
                int isSave = this._repo.Create(category);
                TempData["isSave"] = isSave;
                TempData["message"] = "La catégorie a bien été sauvegardée";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            Categories category = this._repo.Get(id);
            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Categories category = this._repo.Get(id);
                category.Title = collection["Title"];
                int isUpdate = this._repo.Update(category);
                TempData["isSave"] = isUpdate;
                TempData["message"] = "La categorie a bien été éditée";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CategoriesController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Categories category = this._repo.Get(id);
                int isDelete = this._repo.Delete(category);
                TempData["isSave"] = isDelete;
                TempData["message"] = "La catégorie a bien été supprimée";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
