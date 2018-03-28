using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xie_Db;
using Xie_MyBlog.Controllers;

namespace Xie_UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private HomeController _controller;
       
        public UnitTest1(XieMyBlogDbContext dbContext)
        {
            _controller= new HomeController(dbContext);
        }
        [TestMethod]
        public void TestMethod1()
        {
             //_controller.Index();
            
        }
    }
}
