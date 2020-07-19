using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class APIHelper
    {
        public static List<string> JsonSerializeToStringList<T>(List<T> data)
        {
            List<string> result = new List<string>();
            foreach (var item in data)
            {
                result.Add(JsonConvert.SerializeObject(item, Formatting.Indented));
            }

            return result;
        }
    }
}
