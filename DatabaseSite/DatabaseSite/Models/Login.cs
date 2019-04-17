using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSite.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "user name")]
        
        [RegularExpression(@"^[a-zA-Z""'\s-]*$", ErrorMessage = "Field must only contain uppercase and lowercase letters")]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}