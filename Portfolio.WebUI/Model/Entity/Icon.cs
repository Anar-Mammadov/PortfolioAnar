using Riode.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity
{
    public class Icon : BaseEntity
    {
        public int ServiceId { get; set; }
        public string Icons { get; set; }
        public virtual Service Service { get; set; }
    }
}
