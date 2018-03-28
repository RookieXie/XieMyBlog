using System;
using System.Collections.Generic;
using System.Text;

namespace Xie_BlogData.Data
{
    public class XBlogUser:XBlogBase
    {
       
        public string UserName { get; set; }

        public string NickName { get; set; }

        public string PassWord { get; set; }

        public bool? IsAction { get; set; }
        
    }
}
