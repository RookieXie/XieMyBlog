using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;
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
        public DbSet<XBlogTitleType> XBlogTitleType { get; set; }

        public DbSet<XBlogArticle> XBlogArticle { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new XBlogUserMap());
            modelBuilder.ApplyConfiguration(new XBlogLogMap());
            modelBuilder.ApplyConfiguration(new XBlogTitleTypeMap());
            modelBuilder.ApplyConfiguration(new XBlogArticleMap());
        }
        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            XBlogBase model = entity as XBlogBase;
            if (model != null)
            {
                if (string.IsNullOrEmpty(model.Orgnazation))
                {
                    model.Orgnazation = XBlogSingleton.Current.FControlUnitID;//Singleton.Current.FControlUnitID;
                }
                if (string.IsNullOrEmpty(model.Creator))
                {
                    model.Creator = XBlogSingleton.Current.UserID; //Singleton.Current.UserID;
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
                    model.Updator = XBlogSingleton.Current.UserID; //Singleton.Current.UserID;
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
                model.Updator = XBlogSingleton.Current.UserID;// Singleton.Current.UserID;
            }
            return base.Update(entity);
        }
        public override Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            XBlogBase model = entity as XBlogBase;
            if (model != null)
            {
                if (string.IsNullOrEmpty(model.Orgnazation))
                {
                    model.Orgnazation = XBlogSingleton.Current.FControlUnitID;//Singleton.Current.FControlUnitID;
                }
                if (string.IsNullOrEmpty(model.Creator))
                {
                    model.Creator = XBlogSingleton.Current.UserID; //Singleton.Current.UserID;
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
                    model.Updator = XBlogSingleton.Current.UserID; //Singleton.Current.UserID;
                }
            }
            return base.AddAsync(entity, cancellationToken);
        }
    }
}
