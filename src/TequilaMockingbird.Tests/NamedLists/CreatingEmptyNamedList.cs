using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;
using Shouldly;

namespace TequilaMockingbird.Tests.NamedLists
{
    public class CreatingEmptyNamedList
    {
        private TestDataGenerator _generator;

        public void GivenGeneratorWithEmptyNamedList()
        {
            _generator = new TestDataGeneratorBuilder()
                .WithList("mylist", new object[0])
                .Build();
        }

        public void ThenGettingValueFromEmptyListReturnsNull()
        {
            _generator
                .GetFromList<object>("mylist")
                .ShouldBe(null);
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
