using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.Models;
using TestEntity2.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace TestEntity2.Controllers
{
    public class UsersController : Controller
    {

        UserRepostory _repo;

        public UsersController(UserRepostory userRepostory)
        {
            _repo = userRepostory;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            ViewBag.users = this._repo.getAll();
            return View();
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users user)
        {
            try
            {
                if (user.ConfirmPassword != user.Password)
                {
                    TempData["isSave"] = 0;
                    TempData["message"] = "Les mots de passes ne correspondent pas !";
                    return View(user);
                } else
                {
                    user.Password = this.hashPassword(user.Password);
                    user.ImageProfil = $"https://eu.ui-avatars.com/api/?name={user.Firstname}+{user.Lastname}";
                    user.CreatedAt = DateTime.Now;
                    int isSave = this._repo.Create(user);
                    TempData["isSave"] = isSave;
                    TempData["message"] = "l'utilisateur a bien été sauvegardé";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            Users user = this._repo.Get(id);
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Users user)
        {
            try
            {
                Users userUpdate = this._repo.Get(id);
                userUpdate.Username = user.Username;
                userUpdate.Firstname = user.Firstname;
                userUpdate.Lastname = user.Lastname;
                userUpdate.Email = user.Email;
                int isSave = this._repo.Update(userUpdate);
                TempData["isSave"] = isSave;
                TempData["message"] = "l'utilisateur a bien été édité";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: UsersController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Users user = this._repo.Get(id);
                int isDelete = this._repo.Delete(user);
                TempData["isSave"] = isDelete;
                TempData["message"] = "L'utilisateur a bien été supprimé";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string hashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }

    }
}
