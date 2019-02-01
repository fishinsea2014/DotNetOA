using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class ActivityResult
    {
        /// <summary>
        /// Result: 0->pass, 1->reject
        /// </summary>
        public short Result { get; set; }


        //Keep stepInfo in Data
        public object Data { get; set; }

        public string NextStepBookMarkName { get; set; }
    }
}
