using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TequilaMockingbird;
using Shouldly;

namespace TequilaMockingbird.Tests.ReadmeTests
{
    public class BuiltInLists
    {
        readonly TestDataGenerator _generator = new TestDataGeneratorBuilder().Build();

        [Fact]
        public void GetFirstNameReturnsSomeData()
        {
            _generator.GetFirstName().ShouldNotBeEmpty();
        }
    }
}
