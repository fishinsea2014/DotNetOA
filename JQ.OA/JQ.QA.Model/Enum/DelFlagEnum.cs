using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.QA.Model.Enum
{
    public enum DelFlagEnum
    {
        /// <summary>
        /// Normal user
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Logic deleted user
        /// </summary>
        LogicDelete = 1,


        /// <summary>
        /// Physical deleted user
        /// </summary>
        PhysicDelete =2
    }
}
