using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TequilaMockingbird.Extensions
{
    public static partial class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object o)
        {
            if (o == null) return new Dictionary<string, object>();

            return TypeDescriptor
                .GetProperties(o).Cast<PropertyDescriptor>()
                .ToDictionary(x => x.Name, x => x.GetValue(o));
        }
    }
}
