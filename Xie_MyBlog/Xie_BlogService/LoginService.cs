using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System.Linq;
using System.Threading.Tasks;
using Xie_BlogData.Data;
using Xie_Db;

namespace Xie_BlogService
{
    public class LoginService
    {
        private XieMyBlogDbContext _dbContext;
        public LoginService(XieMyBlogDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public Task<bool> Login(string username,string password)
        {
           return  _dbContext.XBlogUser.Select(a=> a.UserName==username&&a.PassWord==password).FirstOrDefaultAsync();
        }
    }
}
