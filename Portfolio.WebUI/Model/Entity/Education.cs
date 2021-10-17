using Riode.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity
{
    public class Education : BaseEntity
    {
        public string TimeInterval { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string LinkDiploma { get; set; }
        public string Description { get; set; }
        public string CompanyLocation { get; set; }
    }
}
