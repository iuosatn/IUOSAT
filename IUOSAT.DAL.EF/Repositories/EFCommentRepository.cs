using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IUOSAT.DAL.EF.Repositories
{
    public class EFCommentRepository : ICommentRepository
    {
        private readonly ApplicationContext _context;

        public EFCommentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void DeleteComment(int CommentID)
        {
            List<Comment> properties = _context.Comments.Where(p => p.CommentID == CommentID).ToList();
            foreach (Comment comment in properties)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }

        public List<Comment> Find(string query)
        {
            return _context.Comments.Where(c => c.Name == query).ToList();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int CommentID)
        {
            return _context.Comments.Find(CommentID);
        }

        public void SaveComment(Comment Comment)
        {
            if (Comment.CommentID == 0)
            {
                _context.Comments.Add(Comment);
            }
            else
            {
                Comment dbEntry = _context.Comments
                .FirstOrDefault(p => p.CommentID == Comment.CommentID);
                if (dbEntry != null)
                {
                    dbEntry.Name = Comment.Name;
                    dbEntry.DateTime = Comment.DateTime;
                    

                }
            }
            _context.SaveChanges();
        }
    }
}
