using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LecModule
    {
        public string id { get; set; }
        public string name { get; set; }
     

       
        public virtual ICollection<stu_module> stu_module { get; set; }
        [NotMapped]
        public string moduleName { get; set; }
    }
}