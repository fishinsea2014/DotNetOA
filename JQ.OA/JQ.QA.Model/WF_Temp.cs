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
    
    public partial class WF_Temp
    {
        public WF_Temp()
        {
            this.WF_Instance = new HashSet<WF_Instance>();
        }
    
        public int ID { get; set; }
        public string TempName { get; set; }
        public System.DateTime SubTime { get; set; }
        public System.DateTime ModfiedOn { get; set; }
        public short DelFlag { get; set; }
        public string Remark { get; set; }
        public string TempDescription { get; set; }
        public string TempForm { get; set; }
        public short TempStatus { get; set; }
        public int SubBy { get; set; }
    
        public virtual ICollection<WF_Instance> WF_Instance { get; set; }
    }
}