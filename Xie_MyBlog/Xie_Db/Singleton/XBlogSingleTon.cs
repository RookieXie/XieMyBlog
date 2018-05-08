using System;
using System.Collections.Generic;
using System.Text;

namespace Xie_Db
{
    public sealed class XBlogSingleton
    {
        private volatile static XBlogSingleton _instance;
        private static readonly object _lock = new object();

        public static XBlogSingleton CreateInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new XBlogSingleton();
                    }
                }
            }
            return _instance;
        }
        public string UserID { get; set; }
        public string FControlUnitID { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }

        public DateTime BeginTime { get; set; }
        public static XBlogSingleton Current => _instance;
    }
}
