using Ecommerce.Data;
using Ecommerce.Services.Comment;
using Ecommerce.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Comment
{
    public class CommentController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        CommentServices commentService = new CommentServices();
        // GET: Comment
        public JsonResult LeaveComment(CommentViwModel model)
        {
            //var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var user = db.Users.Where(u => u.Username == username && u.Password == password && u.UserTypeID==4).FirstOrDefault();
            JsonResult result = new JsonResult();
            if (user != null)
            {
                try
                {
                    var comment = new Ecommerce.Entities.Comment();

                    comment.Text = model.Text;
                    comment.Rating = model.Rating;
                    comment.EntityID = model.EntityID;
                    comment.RecordID = model.RecordID;
                    comment.UserID = Convert.ToInt32(Session["ID"]);
                    comment.TimeStamp = DateTime.Now;

                    var res = commentService.LeaveComment(comment);

                    result.Data = new { Succes = res };

                }
                catch (Exception ex)
                {
                    result.Data = new { Succes = false, Message = ex.Message };
                }

            }
            else {
                result.Data = new { Succes = false, Message = "Please Login" };
            }
            
            return result;
        }
    }
}