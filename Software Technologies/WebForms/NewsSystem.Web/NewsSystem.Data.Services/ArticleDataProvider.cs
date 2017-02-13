using NewsSystem.Data.Services.Contracts;
using System.Linq;
using NewsSystem.Data.Models;
using NewsSystem.Data.Repositories;
using System;

namespace NewsSystem.Data.Services
{
    public class ArticleDataProvider : IArticleDataProvider
    {
        private IRepository<Article> articles;

        public ArticleDataProvider(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public IQueryable<Article> GetTop(int count)
        {
            return this.articles
                .All()
                .OrderByDescending(x => x.Likes.Count())
                .Take(count);
        }

        public Article GetById(int id)
        {
            return this.articles.GetById(id);
        }

        public void Update(int id, Article updatedArticle)
        {
            var articleToUpdate = this.articles.GetById(id);

            articleToUpdate.Title = updatedArticle.Title;
            articleToUpdate.CategoryId = updatedArticle.CategoryId;
            articleToUpdate.Content = updatedArticle.Content;

           // this.articles.Update(articleToUpdate);
            this.articles.SaveChanges();
        }

        public void Delete(int id)
        {
            this.articles.Delete(id);
            this.articles.SaveChanges();
        }

        public void Create(Article article)
        {
            this.articles.Add(article);
            this.articles.SaveChanges();
        }
    }
}
