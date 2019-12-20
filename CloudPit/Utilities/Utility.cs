using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CloudPit.Utilities
{
    public static class Utility
    {
        public static T CombineProperties<T>(T target, T source)
        {
            typeof(T)
            .GetProperties()
            .Select(
                (PropertyInfo pInfo) => new KeyValuePair<PropertyInfo, object>( pInfo, pInfo.GetValue(source, null) )
             )
            .Where(
                (KeyValuePair<PropertyInfo, object> kv) => kv.Value != null).ToList()
            .ForEach((KeyValuePair<PropertyInfo, object> kv) => kv.Key.SetValue(target, kv.Value, null));

            return target; // target after modification
        }
    }
}
