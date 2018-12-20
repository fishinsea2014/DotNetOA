//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JQ.QA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        public Department()
        {
            this.UserInfoes = new HashSet<UserInfo>();
            this.Roles = new HashSet<Role>();
        }
    
        public int ID { get; set; }
        public string DepName { get; set; }
        public Nullable<short> ParentId { get; set; }
        public string DepMasterId { get; set; }
        public string DepNo { get; set; }
        public string IsLeaf { get; set; }
        public Nullable<int> Level { get; set; }
        public string TreePath { get; set; }
        public Nullable<short> DelFlag { get; set; }
        public Nullable<int> SubBy { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Remark { get; set; }
    
        public virtual ICollection<UserInfo> UserInfoes { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
