﻿using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger, PostRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Posts = this._repo.GetPublish();
            return View();
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
