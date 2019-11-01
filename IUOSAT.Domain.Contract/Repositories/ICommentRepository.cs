using IUOSAT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUOSAT.Domain.Contract.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();
        void SaveComment(Comment Comment);
        void DeleteComment(int CommentID);
        Comment GetById(int CommentID);
        List<Comment> Find(string query);
    }
}
