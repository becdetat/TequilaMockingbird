using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TequilaMockingbird.Extensions;

namespace TequilaMockingbird
{
    public class UnknownNamedListException
        : Exception
    {
        public UnknownNamedListException(object key)
            : base("Unknown named list: {0}".FormatWith(key.ToString()))
        {
            Key = key;
        }

        public object Key { get; private set; }
    }
}
