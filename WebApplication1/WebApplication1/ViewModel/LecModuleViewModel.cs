using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class LecModuleViewModel
    {
        public HomeModule HomeModule { get; set; }
        public List<LecModule> LecModule { get; set; }
    }
}