using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xie_BlogData.Data;
using Xie_Db;

namespace Xie_EntityFrameworkCore.netLog4
{
    public class XBlogLogActionFilter:ActionFilterAttribute
    {
        private readonly ILogger _logger;
        private XieMyBlogDbContext _dbContext;

        public XBlogLogActionFilter(ILoggerFactory loggerFactory, XieMyBlogDbContext dbContext)
        {
            _logger = loggerFactory.CreateLogger("LogActionFilter");
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            XBlogLog log = new XBlogLog();
            //log.FID = "321";
            //_dbContext.XBlogLog.Add(log);
            //_dbContext.SaveChanges();
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //_logger.LogDebug("2");
            base.OnActionExecuted(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //_logger.LogDebug("3");
            base.OnResultExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            //_logger.LogDebug("4");
            base.OnResultExecuted(context);
        }
    }
}
