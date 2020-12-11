using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LecStatModule
    {
        public string id { get; set; }
        public string name { get; set; }

        public string intake { get; set; }

        public int countAPlus { get; set; }
        public int countA { get; set; }
        public int countAMin { get; set; }
        public int countBPlus { get; set; }
        public int countB { get; set; }
        public int countBMin { get; set; }
        public int countCPlus { get; set; }
        public int countC { get; set; }
        public int countCMin { get; set; }

        public virtual ICollection<stu_module> stu_module { get; set; }
        [NotMapped]
        public string moduleName { get; set; }
    }
}