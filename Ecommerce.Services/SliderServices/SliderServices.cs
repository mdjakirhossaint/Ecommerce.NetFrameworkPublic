using Ecommerce.Data;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.SliderServices
{
    public class SliderServices
    {
        EcommerceContext db = new EcommerceContext();
        public List<Slider> GetAllSliders()
        {
            return db.Sliders.ToList();
        }


        public void SaveSlider(Slider slider)
        {
            db.Sliders.Add(slider);
            db.SaveChanges();
        }
    }
}
