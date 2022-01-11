using Ecommerce.Entities;
using Ecommerce.Services.BannerServices;
using Ecommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class BannerController : Controller
    {
        BannerServices bannerServices = new BannerServices();
        // GET: Banner
        public ActionResult Index()
        {
            var bannerlist = bannerServices.GetAllBanner();
            return View(bannerlist);
        }
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(CreateBannerModel model)
        {
            Banner banner = new Banner();

            banner.BannerName = model.BannerName;
            banner.ProductURL = model.ProductURL;
            banner.Status = model.Status;


            if (!string.IsNullOrEmpty(model.BannerPictures))
            {
                var pictureIDs = model.BannerPictures
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(ID => int.Parse(ID)).ToList();

                banner.BannerPictures = new List<BannerPicture>();
                banner.BannerPictures.AddRange(pictureIDs
                    .Select(x => new BannerPicture() { PictureID = x }).ToList());
            }
            bannerServices.SaveBanner(banner);

            return RedirectToAction("Index");
        }
    }
}