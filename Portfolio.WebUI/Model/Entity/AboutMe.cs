using Riode.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity
{
    public class AboutMe : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Experience { get; set; }

        public string CareerLevel { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
       
    }
}
