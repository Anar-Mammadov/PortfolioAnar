using Riode.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity
{
    public class Service: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Icon>  Icons{ get; set; }

    }
}
