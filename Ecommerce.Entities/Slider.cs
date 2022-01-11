using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Slider
    {
        public int ID { get; set; }
        public string SliderName { get; set; }
        public string HeadingOne { get; set; }
        public string HeadingTwo { get; set; }
        public string HeadingThree { get; set; }
        public string HeadingFour { get; set; }
        public string HeadingFive { get; set; }
        public string HeadingSix { get; set; }
        public bool Status { get; set; }
        public DateTime? GetDate { get; set; }

        public virtual List<SliderPicture> SliderPictures { get; set; }
    }
}
