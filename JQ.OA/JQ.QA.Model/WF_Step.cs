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
    
    public partial class WF_Step
    {
        public int ID { get; set; }
        public System.DateTime SubTime { get; set; }
        public System.DateTime ProcessTime { get; set; }
        public int ProcessBy { get; set; }
        public string StepName { get; set; }
        public string Comment { get; set; }
        public int FlowTo { get; set; }
        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }
        public short State { get; set; }
        public int WF_InstanceID { get; set; }
        public int ParentStepId { get; set; }
        public int Sort { get; set; }
        public System.Guid InstanceId { get; set; }
        public bool IsProcessed { get; set; }
    
        public virtual WF_Instance WF_Instance { get; set; }
    }
}
