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
        [Display(Name = "User Name")]
        [RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}