using System;
using System.IO;
using NUnit.Framework;

namespace CodeJam.Main.UnitTests
{
    [TestFixture]
    public class BuilderTests
    {
        private IBuilder _builder;
        private ICounter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CodeJamCounter();
        }

        [TearDown]
        public void TearDown()
        {
            _builder = null;
            _sut = null;
        }

        [TestCase(1, "1")]
        [TestCase(2, "1 2")]
        [TestCase(3, "1 2 fizz")]
        [TestCase(4, "1 2 fizz 4")]
        [TestCase(5, "1 2 fizz 4 buzz")]
        [TestCase(10, "1 2 fizz 4 buzz fizz 7 8 fizz buzz")]
        [TestCase(15, "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz")]
        public void When_input_number_then_print_and_return_counted_string(int number, string expectedResult)
        {
            using (var sw = new StringWriter())
            {
                // Arrange
                _builder = new ConsoleBuilderDecorator(new TextBuilder());
                Console.SetOut(sw);

                // Act
                _sut.Count(_builder, number);

                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedResult));
                Assert.That(_builder.GetFullString(), Is.EqualTo(expectedResult));
            }
        }
    }
}
