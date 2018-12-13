using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Common
{
    public class SerializerHelper
    {
        /// <summary>
        /// Serialise an object to a string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToString (object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// Deserialise a string to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeSerializeToObject<T> (string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
