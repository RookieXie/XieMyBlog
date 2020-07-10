using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Xie_BlogService;
using Xie_Db;
using Xie_BlogData.Data;

namespace Xie_MyBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TitleController : ControllerBase
    {
        private XBlogArticleService _articleService;

        public TitleController(XBlogArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public string ArticleList()
        {
            return "TitleController";
        }
        public  List<XBlogTitleType> TitleType()
        {
            var list = _articleService.GetArticleTypeList();
            return list;
        }
        [HttpGet("{signName}")]
        public async Task<string> AddArticleType(string signName)
        {
           var res= await _articleService.AddArticleType(signName);
            if (res > 0)
            {
                return "1";
            }
            return "0";
        }
    }
}