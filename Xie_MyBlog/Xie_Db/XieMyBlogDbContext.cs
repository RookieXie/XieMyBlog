using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using Xie_BlogData.Data;
using Xie_Db.Map;

namespace Xie_Db
{
    public class XieMyBlogDbContext:DbContext
    {
        public XieMyBlogDbContext(DbContextOptions<XieMyBlogDbContext> options):base(options)
        {

        }

        public DbSet<XBlogUser> XBlogUser { get; set; }
        public DbSet<XBlogLog> XBlogLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new XBlogUserMap());
            modelBuilder.ApplyConfiguration(new XBlogLogMap());
        }
        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            XBlogBase model = entity as XBlogBase;
            if (model != null)
            {
                if (string.IsNullOrEmpty(model.Orgnazation))
                {
                    model.Orgnazation = "";//Singleton.Current.FControlUnitID;
                }
                if (string.IsNullOrEmpty(model.Creator))
                {
                    model.Creator = ""; //Singleton.Current.UserID;
                }
                if (!model.CreateTime.HasValue)
                {
                    model.CreateTime = new DateTime?(DateTime.Now);
                }
                if (!model.UpdateTime.HasValue)
                {
                    model.UpdateTime = new DateTime?(DateTime.Now);
                }
                if (string.IsNullOrEmpty(model.Updator))
                {
                    model.Updator = ""; //Singleton.Current.UserID;
                }
            }
            return base.Add(entity);

        }

        public override EntityEntry<TEntity> Update<TEntity>( TEntity entity)
        {
            XBlogBase model = entity as XBlogBase;
            if (model != null)
            {
                model.UpdateTime = new DateTime?(DateTime.Now);
                model.Updator = "";// Singleton.Current.UserID;
            }
            return base.Update(entity);
        }
    }
}
