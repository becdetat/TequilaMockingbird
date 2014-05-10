using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TequilaMockingbird.DataSets
{
    public interface IDataSet<T>
    {
        IEnumerable<T> GetData();
    }
}
