using System;
using System.Collections.Generic;
using System.Text;

namespace Xie_BlogData.Data
{
    public class XBlogArticle : XBlogBase
    {
        public string Title { get; set; }
        public int? TitleType { get; set; }
        public string Content { get; set; }

    }
}
