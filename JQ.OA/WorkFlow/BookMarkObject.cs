using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow
{
    public class BookMarkObject<T>
    {
        public string BookMark { get; set; }
        public int StepId { get; set; }
        public T Result { get; set; }
    }
}
