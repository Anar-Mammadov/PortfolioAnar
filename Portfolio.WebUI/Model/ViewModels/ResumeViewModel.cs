using Portfolio.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.ViewModels
{
    public class ResumeViewModel 


    {
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
        public Bio Bios { get; set; }
        public List<Skill> Skills { get; set; }


    }
}
