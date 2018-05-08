using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Xie_BlogData.Data;
using Xie_BlogService;
using Xie_Db;
using Xie_EntityFrameworkCore.netLog4;
using Xie_MyBlog.Models;

namespace Xie_MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private LoginService _loginService;

        public HomeController(XieMyBlogDbContext dbContext, IDistributedCache distributedCache)
        {
            _loginService = new LoginService(dbContext, distributedCache);
        }

        [ServiceFilter(typeof(XBlogLogActionFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<string> Login(string username, string password)
        {
            var res = await _loginService.Login(username, password);
            if (res!=null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("FullName", username),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. Required when setting the 
                    // ExpireTimeSpan option of CookieAuthenticationOptions 
                    // set with AddCookie. Also required when setting 
                    // ExpiresUtc.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    RedirectUri = "/Home/Index"
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return "1";
            }
            return "0";
        }
        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
    CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<string> Register(string userName,string nickName,string password)
        {
           var res= await _loginService.Register(userName, nickName, password);
            if (res>0)
            {
                return "1";
            }
            return "0";
        }

        public IActionResult RegisterView()
        {
            return View();
        }
    }
}
