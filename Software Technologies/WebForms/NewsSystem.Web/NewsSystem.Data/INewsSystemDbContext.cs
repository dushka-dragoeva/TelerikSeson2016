using NewsSystem.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NewsSystem.Data
{
    public interface INewsSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Like> Likes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}
