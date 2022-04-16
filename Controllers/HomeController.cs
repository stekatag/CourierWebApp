﻿using CourierWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CourierWebApp.Data;
using Microsoft.AspNetCore.Identity;

namespace CourierWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //private readonly UserManager<ApplicationUser> userManager;

        //public AdministrationController(UserManager<ApplicationUser> userManager)
        //{
        //    this.userManager = userManager;
        //}

        //[HttpGet]
        //public IActionResult ListUsers()
        //{
        //    var users = userManager.Users;
        //    return View(users);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
