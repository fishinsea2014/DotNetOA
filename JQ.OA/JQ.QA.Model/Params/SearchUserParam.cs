using JQ.QA.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.QA.Model
{
    public class SearchUserParam : BaseQueryParams
    {
        public string SName { get; set; }   
        public string SPhone { get; set; }
    }
}
