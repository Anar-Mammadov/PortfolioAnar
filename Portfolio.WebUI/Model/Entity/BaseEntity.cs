using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.Model.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedData { get; set; } = DateTime.Now;
        public int? DeleteByUserId { get; set; }
        public DateTime? DeletedData { get; set; }
    }
}
