using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xie_BlogData.Data;
using Xie_Db;

namespace Xie_BlogService
{
    public class XBlogArticleService
    {
        private XieMyBlogDbContext _dbContext;
        private IDistributedCache _distributedCache;
        public XBlogArticleService(XieMyBlogDbContext dbContext, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _distributedCache = distributedCache;
        }
        public List<XBlogTitleType> GetArticleTypeList()
        {
           return  _dbContext.XBlogTitleType.Where(a => a.IsDelete == null || a.IsDelete == false).ToList();
        }
        public Task<int> AddArticleType(string signName)
        {
            XBlogTitleType model = new XBlogTitleType();
            model.TypeInt = 1;
            model.TypeName = signName;
            model.FID= Guid.NewGuid().ToString();
            _dbContext.XBlogTitleType.AddAsync(model);
            return _dbContext.SaveChangesAsync();
        }
    }
}
