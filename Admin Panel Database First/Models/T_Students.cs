//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin_Panel_Database_First.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Students
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public Nullable<int> Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public Nullable<bool> Marital { get; set; }
        public string ImageName { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
    }
}
