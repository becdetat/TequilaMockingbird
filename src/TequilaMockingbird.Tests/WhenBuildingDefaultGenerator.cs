using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;
using TequilaMockingbird;
using Shouldly;

namespace TequilaMockingbird.Tests
{
    public class WhenBuildingDefaultGenerator
    {
        private TestDataGeneratorBuilder _builder;
        private TestDataGenerator _generator;

        public void GivenAnUnconfiguredBuilder()
        {
            _builder = new TestDataGeneratorBuilder();
        }

        public void WhenBuildingTheGenerator()
        {
            _generator = _builder.Build();
        }

        public void ThenWeShouldGetTheDefaultGenerator()
        {
            _generator.ShouldNotBe(null);
        }

        public void ThenThereShouldBePreSeededFirstNames()
        {
            _generator.GetFirstName().ShouldNotBeEmpty();
        }

        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
