using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xie_BlogData.Data;

namespace Xie_Db.Map
{
    public class XBlogUserMap:IEntityTypeConfiguration<XBlogUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<XBlogUser> builder)
        {
            builder.ToTable("XBlogUser");
            builder.HasKey(x=>x.FID);
            builder.Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).HasColumnName("UserName").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.NickName).HasColumnName("NickName").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.PassWord).HasColumnName("PassWord").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.IsAction).HasColumnName("IsAction").IsRequired(false);
            builder.Property(x => x.IsDelete).HasColumnName("IsDelete").IsRequired(false);
            builder.Property(x => x.CreateTime).HasColumnName("CreateTime").IsRequired(false);
            builder.Property(x => x.Creator).HasColumnName("Creator").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.UpdateTime).HasColumnName("UpdateTime").IsRequired(false);
            builder.Property(x => x.Updator).HasColumnName("Updator").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Orgnazation).HasColumnName("Orgnazation").IsRequired(false).HasMaxLength(50);
        }
    }
}
