using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.Entity.FormModel
{
    public class LoginFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
