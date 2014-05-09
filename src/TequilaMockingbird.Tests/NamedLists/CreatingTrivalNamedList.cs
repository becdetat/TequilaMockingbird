using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace TequilaMockingbird.Tests.NamedLists
{
    public class CreatingTrivalNamedList
    {
        private readonly object[] _values = {"one", "two", "three", 123456};
        private TestDataGenerator _generator;

        public void GivenGeneratorWithNamedList()
        {
            _generator = new TestDataGeneratorBuilder()
                .WithList("mylist", _values)
                .Build();
        }

        public void ThenGettingValueFromUnknownListThrowsUnknownNamedListException()
        {
            Should.Throw<UnknownNamedListException>(() => _generator.GetFromList<string>("unknown list"));
        }

        public void ThenGettingValueFromNamedListReturnsValueFromTheList()
        {
            var value = _generator.GetFromList<string>("mylist");

            _values.ShouldContain(value);
        }

        public void ThenGettingIntValueReturnsTheOnlyIntValue()
        {
            var value = _generator.GetFromList<int>("mylist");

            value.ShouldBe(123456);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
