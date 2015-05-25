using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Safehaus.IntranetGaming.Utilities
{
    public static class StringUtilities
    {
        public static string ToJsonString(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
