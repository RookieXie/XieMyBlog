using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Xie_BlogData.Data;
using Xie_Db;
using Xie_MyBlog.Controllers;
using Xunit;

namespace XUnitTestBlog
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            
            var mockRepo = new Mock<XieMyBlogDbContext>();
            //mockRepo.Setup(op => op.XBlogUser).Returns(Mock.Of<DbSet<XBlogUser>>);
            //mockRepo.Setup(op => op.XBlogLog).Returns(Mock.Of<DbSet<XBlogLog>>);
            var controller = new HomeController(mockRepo.Object);
            var res = await controller.Login("123", "123456");

            // Assert
            var viewResult = Assert.IsType<int>(res);

            Assert.Equal(1, viewResult);
        }
    }
}
