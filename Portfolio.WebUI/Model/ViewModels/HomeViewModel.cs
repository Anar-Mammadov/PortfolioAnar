using Portfolio.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.ViewModels
{
    public class HomeViewModel
    {
        public List<Service> Services{ get; set; }
        public Icon Icons { get; set; }
        public AboutMe Aboutme { get; set; }

    }
}
