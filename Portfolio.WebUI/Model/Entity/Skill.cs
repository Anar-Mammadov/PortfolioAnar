using Riode.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity
{
    public class Skill : BaseEntity
    {
        public string SkillsName { get; set; }
        public string SkillsPercentage { get; set; }
        public string SkillsDescription { get; set; }
        public bool IsHardSkill { get; set; } 
    }
}
