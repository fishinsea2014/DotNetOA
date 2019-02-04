using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.WFEnum
{
    public enum WFEnum
    {
        IsPass = 0,
        IsContinue =3,
        IsReject =1,
        IsCancel =2,
    }

    public enum WFStateEnum
    {
        InProcess=0,
        IsComplete=1,
        IsCanceled =2,
            
    }

}
