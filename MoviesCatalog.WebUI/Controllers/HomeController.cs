﻿using Microsoft.AspNetCore.Mvc;

namespace MoviesCatalog.WebUI.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }
}