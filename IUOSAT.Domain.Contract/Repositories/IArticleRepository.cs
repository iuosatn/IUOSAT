using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        void SaveArticle(Article Article);
        void DeleteArticle(int ArticleID);
        Article GetById(int ArticleID);
        List<Article> Find(string query);
    }
}
