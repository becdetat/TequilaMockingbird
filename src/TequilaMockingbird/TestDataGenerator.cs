using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TequilaMockingbird
{
    public class TestDataGenerator
    {
        IDictionary<object, IEnumerable<object>> _lists = new Dictionary<object, IEnumerable<object>>();
        readonly Random _random = new Random();

        public TestDataGenerator(IDictionary<object, IEnumerable<object>> lists)
        {
            _lists = lists;
        }
        
        public T GetFromList<T>(object key)
        {
            if (!_lists.ContainsKey(key))
                throw new UnknownNamedListException(key);

            var availableItems = _lists[key].OfType<T>().ToArray();

            if (!availableItems.Any())
                return default(T);

            return availableItems[_random.Next(0, availableItems.Length - 1)];
        }

        public string GetFirstName()
        {
            return GetFromList<string>("FirstName");
        }
    }
}
