using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleProTraining.Models
{
    public class Building
    {
        [Key]
        public int ID { get; set; }
        public string Address { get; set; }
        public virtual Department Department { get; set; }
    }
}