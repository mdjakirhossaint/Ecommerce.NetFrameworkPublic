using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class LayoutViewModel
    {
        public virtual List<Branding> Branding { get; set; }
        
    }
}