using NewsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Data.Services.Contracts
{
    public interface IArticleServices
    {
        IQueryable<Article> GetTop(int count);

        IQueryable<Article> GetAll();

        Article GetById(int id);

        void Update(int id, Article updatedArticle);

        void Delete(int id);

        void Create(Article article);

    }
}
