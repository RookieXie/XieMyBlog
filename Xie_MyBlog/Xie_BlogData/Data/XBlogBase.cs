using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xie_BlogData.Data
{
    public class XBlogBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [MaxLength(50)]
        public string FID { get; set; }
        /// <summary>
        /// 逻辑删除字段
        /// </summary>
        public bool? IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 最好修改人员
        /// </summary>
        public string Updator { get; set; }
        /// <summary>
        /// 组织
        /// </summary>
        public string Orgnazation { get; set; }

    }
}
