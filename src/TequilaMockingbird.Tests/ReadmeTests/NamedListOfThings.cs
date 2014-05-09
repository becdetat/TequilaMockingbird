using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TequilaMockingbird.Tests.ReadmeTests
{
    public class NamedListOfThings
    {
        /*
         * Configure a generator with a named list:

	        var generator = new TequilaMockingbird.TestDataGeneratorBuilder()
		        .WithList("my list", new[] { "one", "two", "three"})
		        .Build();

	        var foos = new Collection<Foo>();
	        foos.Add(new Foo(generator.GetFromList<string>("my list")));
	        foos.Add(new Foo(generator.GetFromList<string>("my list")));
	        foos.Add(new Foo(generator.GetFromList<string>("my list")));
	        foos.Add(new Foo(generator.GetFromList<string>("my list")));

        `WithList` takes an object as the key and an ienumerable of object as the list.

	        var generator = new TequilaMockingbird.TestDataGeneratorBuilder()
		        .WithList(SomeEnum.MyList, new[] { 4, 5, 6 })
		        .Build();

        `GetFromList` uses the generic type to cast a random member of the list to the appropriate type.
        */
    }
}
