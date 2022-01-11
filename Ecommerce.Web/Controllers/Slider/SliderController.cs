using Ecommerce.Entities;
using Ecommerce.Services.SliderServices;
using Ecommerce.Web.Models.SliderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers.Slider
{
    public class SliderController : Controller
    {
        SliderServices sliderServices = new SliderServices();
        // GET: Slider
        public ActionResult Index()
        {
            var sliderList = sliderServices.GetAllSliders();
            return View(sliderList);
        }
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlider(CreateSliderModel model)
        {
            Entities.Slider slider = new Entities.Slider();

            slider.SliderName = model.SliderName;
            slider.HeadingOne = model.HeadingOne;
            slider.HeadingTwo = model.HeadingTwo;
            slider.HeadingThree = model.HeadingThree;
            slider.HeadingFour = model.HeadingFour;
            slider.HeadingFive = model.HeadingFive;
            slider.HeadingSix = model.HeadingSix;

            slider.GetDate = System.DateTime.Now;


            if (!string.IsNullOrEmpty(model.SliderPictures))
            {
                var pictureIDs = model.SliderPictures
                    .Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(ID => int.Parse(ID)).ToList();

                slider.SliderPictures = new List<SliderPicture>();
                slider.SliderPictures.AddRange(pictureIDs
                    .Select(x => new SliderPicture() { PictureID = x }).ToList());
            }
            sliderServices.SaveSlider(slider);

            return RedirectToAction("Index");
        }
    }
}