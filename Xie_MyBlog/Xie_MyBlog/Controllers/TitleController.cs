using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Xie_BlogService;
using Xie_Db;

namespace Xie_MyBlog.Controllers
{
    public class TitleController : Controller
    {
        private XBlogArticleService _articleService;

        public TitleController(XieMyBlogDbContext dbContext, IDistributedCache distributedCache)
        {
            _articleService = new XBlogArticleService(dbContext, distributedCache);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TitleType()
        {
            var list = _articleService.GetArticleTypeList();
            return View(list);
        }

        public async Task<string> AddArticleType(string signName)
        {
           var res= await _articleService.AddArticleType(signName);
            if (res > 0)
            {
                return "1";
            }
            return "0";
        }
        public IActionResult ArticleList()
        {
            return View();
        }

        public IActionResult ArticleDetail()
        {
            return View();
        }
    }
}