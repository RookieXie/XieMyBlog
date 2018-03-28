using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        
        public HomeController(XieMyBlogDbContext dbContext)
        {
            _loginService = new LoginService(dbContext);
        }

        [ServiceFilter(typeof(XBlogLogActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username,string password)
        {
            _loginService.Login(username, password);
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
