﻿using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class SuperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}