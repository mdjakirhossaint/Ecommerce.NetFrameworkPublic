

using Ecommerce.Entities;
using Ecommerce.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Common
{
    public class SharedController : Controller
    {
        SharedServices Service = new SharedServices();

        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();


            List<object> picturesJSON = new List<object>();

            var pictures = Request.Files;

            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);



                var path = Server.MapPath("~/Content/images/") + fileName;

                picture.SaveAs(path);

                var dbPicture = new Picture();
                dbPicture.PictureURL = fileName;
                int pictureID = Service.SavePicture(dbPicture);

                picturesJSON.Add(new { ID = pictureID, pictureUrl = fileName });
            }
            result.Data = picturesJSON;

            return result;
        }

    }
}