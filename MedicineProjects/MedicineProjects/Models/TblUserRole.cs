//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicineProjects.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUserRole
    {
        public int UserRoleID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string PageName { get; set; }
        public Nullable<bool> IsCreate { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<bool> IsUpdate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual TblUser TblUser { get; set; }
    }
}
