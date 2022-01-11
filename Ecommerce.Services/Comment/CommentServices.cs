using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Comment
{
    public class CommentServices
    {
        EcommerceContext db = new EcommerceContext();
        public bool LeaveComment(Ecommerce.Entities.Comment comment)
        {
            db.Comments.Add(comment);
            return db.SaveChanges() > 0;
        }
        public List<Ecommerce.Entities.Comment> GetComments(int enitiyID, int recordID)
        {
            return db.Comments.Where(x => x.EntityID == enitiyID && x.RecordID == recordID).ToList();
        }

        //public List<Ecommerce.Entities.Comment> GetCommentsByUser(string userID, int entityID)
        //{
        //    return db.Comments.Where(x => x.UserID == userID).Where(x => x.EntityID == entityID).OrderByDescending(x => x.TimeStamp).ToList();
        //}
        public List<Ecommerce.Entities.Comment> GetAllCommentByUserID(int ID)
        {
            var commentlist = db.Comments.Where(x => x.UserID == ID).ToList();
            return commentlist;
        }
        public List<Ecommerce.Entities.Comment> GetCommentsByUser(int userID, int entityID)
        {
            return db.Comments.Where(x => x.UserID == userID).Where(x => x.EntityID == entityID).OrderByDescending(x => x.TimeStamp).ToList();
        }
    }
}
