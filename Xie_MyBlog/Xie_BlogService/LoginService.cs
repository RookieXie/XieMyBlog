using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xie_BlogData.Data;
using Xie_Db;
using Xie_EntityFrameworkCore;

namespace Xie_BlogService
{
    public class LoginService
    {
        private XieMyBlogDbContext _dbContext;
        private IDistributedCache _distributedCache;
        public LoginService(XieMyBlogDbContext dbContext, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _distributedCache = distributedCache;
        }
        public Task<XBlogUser> Login(string username, string password)
        {
            Task<XBlogUser> taskUser= _dbContext.XBlogUser.Where(a => a.UserName == username && a.PassWord == password).FirstOrDefaultAsync();
            XBlogUser user = taskUser.Result;
            if (user != null)
            {
                var _user= _distributedCache.GetString(user.FID);
                if (string.IsNullOrEmpty(_user))
                {
                    _distributedCache.SetString(user.FID, user.ToString());
                }
                XBlogSingleton.Current.UserID = user.FID;
                XBlogSingleton.Current.UserName = user.UserName;
                XBlogSingleton.Current.NickName = user.NickName;
                XBlogSingleton.Current.BeginTime = DateTime.Now;
                XBlogSingleton.Current.FControlUnitID = user.Orgnazation ;
            }
            return taskUser;
        }
        public Task<int> Register(string userName, string nickName, string password)
        {
            XBlogUser user = new XBlogUser();
            user.FID = Guid.NewGuid().ToString();
            user.UserName = userName;
            user.NickName = nickName;
            user.PassWord = password;
            user.Orgnazation = "1";
            user.IsAction = true;
            _dbContext.AddAsync(user);
            return _dbContext.SaveChangesAsync();
        }
    }
}
