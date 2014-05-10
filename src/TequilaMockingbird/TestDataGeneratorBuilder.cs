using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TequilaMockingbird
{
    public class TestDataGeneratorBuilder
    {
        IDictionary<object, IEnumerable<object>> _lists = new Dictionary<object, IEnumerable<object>>();

        public TestDataGeneratorBuilder()
        {
            WithList("FirstName", new DataSets.FirstName().GetData());
        }

        public TestDataGenerator Build()
        {
            return new TestDataGenerator(_lists);
        }

        public TestDataGeneratorBuilder WithList(object key, IEnumerable<object> values)
        {
            _lists.Add(key, values);

            return this;
        }
    }
}
