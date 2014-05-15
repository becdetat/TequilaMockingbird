TequilaMockingbird
==================

Highly configurable test data generator.

Note that this isn't necessarily for use in unit tests. Although it definitely could be used in unit tests, generally I would avoid this except for doing some kind of fuzz testing. This is really intended for generating test data for consumption within an application. For example, generate a thousand prepoulated contacts for persisting to the database, to provide some load to the system during development.


## TODOs

- [x] Named list of things
- [ ] built in lists
- [ ] gender hints on first names
- [ ] replace named list
- [ ] append to named list
- [ ] generate a date in a range
- [ ] remember and retrieve the last thing that was generated
- [ ] generate a date within timespan of a fixed date
- [ ] Named configurations
- [ ] Get X number of things


## Example syntax and usage (example driven development)

### Named list of things

Configure a generator with a named list:

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

Note that `.WithList(key, new[] { 4, 5, 6 })` but this doesn't:

	int[] values = new[] { 4, 5, 6 };
	builder.WithList(key, values);

The above causes a compiler error:

	cannot convert from 'int[]' to 'System.Collections.Generic.IEnumerable<object>'

Cast the values to objects first:

	int[] values = new[] { 4, 5, 6 };
	builder.WithList(key, values.OfType<object>());


### built in lists

The OOTB generator has some precanned data:

	.WithList("FirstNames", new[] { "Ben", "John", "Eddie", ... })
	.WithList("LastNames", new[] { "Scott", "Smith", "Van Halen", ... })

	var person = new Person(
		generator.GetFirstName(),
		generator.GetLastName());


### gender hints on first names

	.WithList("FirstNames", new[]{ new HintedListMember("Ben", new{ Gender = Gender.Male }), new HintedListMember("Fred", new { Gender = Gender.NonSpecific}) })

	var malePerson = new Person(
		generator.GetFirstName(hint: new { Gender = Gender.NonSpecific }));

`hint`s are anonymous objects that are dynamically matched to the source hint. Hinting can be applied to anything that is a list of HintedListMember.


### replace named list
	
`.WithList` should replace a list if it exists. so:

	.WithList("LastNames", ...)

will replace the pre-canned list of last names.


### append to named list

	.AppendToList("LastNames", new[] { "some", "new", "items"})

Will throw an InvalidTypeException? if the list being passed in is the incorrect type. (should it? `GetFromList` could just call `innerlist.OfType<T>()...`)


### generate a date in a range

	DateTime t = generator.GetDateBetween(new DateTime(1900, 1, 1)).And(new DateTime(2009, 12, 31));

	DateTimeOffset o = generator.GetDateBetween(new DateTimeOffset(..)).And(new DateTimeOffset(..));


### remember and retrieve the last thing that was generated

Last call to each type of thing gets written to a cache:

	.GetFromList<string>("foos")	// writes to generator.Cache["GetFromList_string_foos"]
	.GetFirstName()	// writes to generator.Cache["GetFirstName"]
	.GetDateBetween(xx, yy)	// writes to generator.Cache["GetDateBetween_xx_yy"]

	.GetLast().GetFromList<string>("foos")	// reads from generator.Cache["GetFromList_string_foos"]
	.GetLast().GetFirstName	// reads from generator.Cache["GetFirstName"]
	.GetLast<T>("GetDateBetween")	// reads from the first key that starts with the provided value


### generate a date within timespan of a fixed date

	// Get a date within 365 days of 2010-01-01
	generator.GetDateWithin(TimeSpan.FromDays(365)).Of(new DateTime(2010, 01, 01))

	// Get a date within 1000 days of 18 years after the last call starting with GetDate
	generator.GetDateWithin(TimeSpan.FromDays(1000)).Of(generator.GetLast<DateTime>("GetDate").AddYears(18))


### Named configurations

	var generator = new TequilaMockingbird.TestDataGeneratorBuilder()
		.WithDate("dob").Between(new DateTime(1960, 1, 1)).And(2010, 1, 1)
		.Build();

	var dateOfBirth = generator.GetDate("dob");


### Get X number of things

	IEnumerable<string> names = generator.Get(1000).Of(x => x.GetFirstName());

	IEnumerable<Person> people = generator.Get(50).Of(x => new Person(x.GetFirstName(), x.GetLastName(), x.GetDate("dob")));


