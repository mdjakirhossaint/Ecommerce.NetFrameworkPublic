using Ecommerce.Entities;
using Ecommerce.Services.Ads;
using Ecommerce.Web.Models.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Ads
{
    public class AdsController : Controller
    {
        AdsServices adsServices = new AdsServices();
        // GET: Ads
        public ActionResult Index()
        {
            var sbannerList = adsServices.GetAllSecoundBanner();

            return View(sbannerList);
        }
        public ActionResult AddAds()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAds(CreateAdsModel model)
        {
            SecoundBanner  secoundBanner = new SecoundBanner();

            secoundBanner.SBannerName = model.SBannerName;
            secoundBanner.Description = model.Description;
            secoundBanner.Status = model.Status;


            if (!string.IsNullOrEmpty(model.SecoundBannerPictures))
            {
                var pictureIDs = model.SecoundBannerPictures
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(ID => int.Parse(ID)).ToList();

                secoundBanner.SecoundBannerPictures = new List<SecoundBannerPicture>();
                secoundBanner.SecoundBannerPictures.AddRange(pictureIDs
                    .Select(x => new SecoundBannerPicture() { PictureID = x }).ToList());
            }
            adsServices.SaveSecoundBanner(secoundBanner);

            return RedirectToAction("Index");
        }
    }
}