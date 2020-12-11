# unit-testing-frameworks

Attributes
NUnit 3.x	MSTest 15.x	xUnit.net 2.x	Comments
[Test]	[TestMethod]	[Fact]	Marks a test method.
[TestFixture]	[TestClass]	n/a	xUnit.net does not require an attribute for a test class; it looks for all test methods in all public (exported) classes in the assembly.
Assert.That
Record.Exception	[ExpectedException]	Assert.Throws
Record.Exception	xUnit.net has done away with the ExpectedException attribute in favor of Assert.Throws. See Note 1
[SetUp]	[TestInitialize]	Constructor	We believe that use of [SetUp] is generally bad. However, you can implement a parameterless constructor as a direct replacement. See Note 2
[TearDown]	[TestCleanup]	IDisposable.Dispose	We believe that use of [TearDown] is generally bad. However, you can implement IDisposable.Dispose as a direct replacement. See Note 2
[OneTimeSetUp]	[ClassInitialize]	IClassFixture<T>	To get per-class fixture setup, implement IClassFixture<T> on your test class. See Note 3
[OneTimeTearDown]	[ClassCleanup]	IClassFixture<T>	To get per-class fixture teardown, implement IClassFixture<T> on your test class. See Note 3
n/a	n/a	ICollectionFixture<T>	To get per-collection fixture setup and teardown, implement ICollectionFixture<T> on your test collection. See Note 3
[Ignore("reason")]	[Ignore]	[Fact(Skip="reason")]	Set the Skip parameter on the [Fact] attribute to temporarily skip a test.
[Property]	[TestProperty]	[Trait]	Set arbitrary metadata on a test
[Theory]	[DataSource]	[Theory]
[XxxData]	Theory (data-driven test). See Note 4
