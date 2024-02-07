using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Domain.Account;
using MoviesCatalog.WebUI.ViewModels;

namespace MoviesCatalog.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _auth;

    public AccountController(IAuthenticate auth)
    {
        _auth = auth;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _auth.Authenticate(model.Email, model.Password);

        if (result)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt. (password must be strong).");
            return View(model);
        }
    }


    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _auth.RegisterUser(model.Email, model.Password);

        if (result)
        {
            return Redirect("/");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong).");
            return View(model);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await _auth.Logout();
        return Redirect("/Account/Login");
    }
}