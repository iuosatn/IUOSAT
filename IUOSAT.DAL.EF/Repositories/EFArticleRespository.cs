using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFArticleRepository : IArticleRepository
    {
        private readonly ApplicationContext _context;

    public EFArticleRepository(ApplicationContext context)
    {
        _context = context;
    }

        public void DeleteArticle(int ArticleID)
        {
            List<Article> properties = _context.Articles.Where(p => p.ArticleID == ArticleID).ToList();
            foreach (Article article in properties)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }

        public List<Article> Find(string query)
        {
            return _context.Articles.Where(c => c.Name == query).ToList();
        }

        public List<Article> GetAll()
        {
            return _context.Articles.ToList();
        }

        public Article GetById(int ArticleID)
        {
            return _context.Articles.Find(ArticleID);
        }

        public void SaveArticle(Article Article)
        {
            if (Article.ArticleID == 0)
            {
                _context.Articles.Add(Article);
            }
            else
            {
                Article dbEntry = _context.Articles
                .FirstOrDefault(p => p.ArticleID == Article.ArticleID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Article.Name;
                    dbEntry.Description = Article.Description;
                    dbEntry.GithubUrl = Article.GithubUrl;
                    dbEntry.PersonID = Article.PersonID;
                    dbEntry.Title = Article.Title;
                    dbEntry.KeyWords = Article.KeyWords;
                    dbEntry.Body = Article.Body;
                }
            }
            _context.SaveChanges();
        }
    }
}
