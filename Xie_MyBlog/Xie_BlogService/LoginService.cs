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
        public bool Login(string username,string password)
        {
            return true;
        }
    }
}
