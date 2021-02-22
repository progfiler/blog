using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2.Models;
using TestEntity2.Repositories;

namespace TestEntity2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostRepository _repo;
        private readonly CategoryRepository _categoryRepository;

        public HomeController(
            ILogger<HomeController> logger,
            PostRepository repo,
            CategoryRepository categoryRepo)
        {
            _logger = logger;
            _repo = repo;
            _categoryRepository = categoryRepo;
        }

        public IActionResult Index()
        {
            ViewBag.Posts = this._repo.GetPublish();
            ViewBag.Categories = this._categoryRepository.GetAll();
            return View();
        }


        // GET: HomeController/Filtered?ids=1,2,3
        [Route("Filtered")]
        public List<Posts> Filtered(string ids)
        {
            List<Posts> posts = new List<Posts>();
            if (ids != null)
            {
                string[] category_ids = ids.Split(',');
                List<int> c = new List<int>();
                foreach (string id in category_ids)
                {
                    c.Add(Convert.ToInt32(id));
                }
                posts = this._repo.GetFilteredPosts(c);
            } else
            {
                posts = this._repo.GetFilteredALlPosts();
            }
            return posts;
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Post = this._repo.Get(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
