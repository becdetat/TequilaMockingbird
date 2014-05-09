using System.Collections.ObjectModel;
using System.Linq;
using Shouldly;
using Xunit;

namespace TequilaMockingbird.Tests.ReadmeTests
{
    public class NamedListOfThings
    {
        [Fact]
        public void ConfigureGeneratorWithNamedList()
        {
            var myList = new[] {"one", "two", "three"};
            var generator = new TequilaMockingbird.TestDataGeneratorBuilder()
                .WithList("my list", myList)
                .Build();

            var foos = new Collection<Foo>();
            foos.Add(new Foo(generator.GetFromList<string>("my list")));
            foos.Add(new Foo(generator.GetFromList<string>("my list")));
            foos.Add(new Foo(generator.GetFromList<string>("my list")));
            foos.Add(new Foo(generator.GetFromList<string>("my list")));

            foos.ShouldAllBe(x => myList.Contains(x.Name));
        }

        [Fact]
        public void EnumAsKeyAndIntsAsValues()
        {
            var myList = new[] {4, 5, 6};
            var myOtherList = new[] {7, 8, 9};

            var generator = new TequilaMockingbird.TestDataGeneratorBuilder()
                .WithList(SomeEnum.MyList, myList.OfType<object>())
                .WithList(SomeEnum.MyOtherList, myOtherList.OfType<object>())
                .Build();

            for (var i = 0; i < 10; i ++)
            {
                myList.ShouldContain(generator.GetFromList<int>(SomeEnum.MyList));
                myOtherList.ShouldContain(generator.GetFromList<int>(SomeEnum.MyOtherList));
            }
        }

        private class Foo
        {
            public Foo(string name)
            {
                Name = name;
            }

            public string Name { get; private set; }
        }

        private enum SomeEnum
        {
            MyList,
            MyOtherList,
        }
    }
}