using Riode.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity
{
    public class BlogPost : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? PublishDate { get; set; }
        public string BlogType { get; set; }
        public string ShortDescription { get; set; }

    }
}
