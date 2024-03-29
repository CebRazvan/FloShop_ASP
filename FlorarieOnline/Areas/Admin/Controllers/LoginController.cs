using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

using Microsoft.AspNetCore.Authentication;
using FlorarieOnline.Areas.Admin.Models;

namespace FlorarieOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        // GET: LoginController
        
        public IActionResult Index() 
        {
            return View();
        }

  

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Здесь происходит проверка учетных данных пользователя, например, в базе данных
                // Предположим, что пользователь существует с указанным email и паролем
                if (IsUserAuthenticated(model.Email, model.Password))
                {
                    // Создаем утверждения (claims) о пользователе
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, model.Email),
                        // Другие утверждения о пользователе, если это необходимо
                    };

                    // Создаем объект ClaimsIdentity на основе утверждений
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Создаем объект ClaimsPrincipal на основе ClaimsIdentity
                    var authProperties = new AuthenticationProperties
                    {
                        // Дополнительные свойства аутентификации, если это необходимо
                    };

                    // Выполняем аутентификацию пользователя и создаем аутентификационный cookie
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    // Перенаправляем пользователя на защищенную страницу или на главную страницу
                    return RedirectToAction("Index", "Home"); // Или на другую страницу, если это необходимо
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // Если произошла ошибка или аутентификация не удалась, возвращаемся на страницу входа с сообщением об ошибке
            Console.WriteLine("eRROR");
            return View();
        }

        private bool IsUserAuthenticated(string email, string password)
        {
            // Здесь вы должны выполнить проверку учетных данных пользователя, например, в базе данных
            // В этом примере просто вернем true, предполагая, что аутентификация всегда проходит успешно
            return true;
        }
    }
} 
 