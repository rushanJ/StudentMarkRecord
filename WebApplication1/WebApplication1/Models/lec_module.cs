//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class lec_module
    {
        public int id { get; set; }
        public int lecturer { get; set; }
        public int module { get; set; }
    
        public virtual lecturer lecturer1 { get; set; }
        public virtual module module1 { get; set; }
    }
}
