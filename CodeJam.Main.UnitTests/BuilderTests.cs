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
        [TestCase(3, "1 2 Fizz")]
        [TestCase(4, "1 2 Fizz 4")]
        [TestCase(5, "1 2 Fizz 4 Buzz")]
        [TestCase(10, "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz")]
        [TestCase(15, "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz")]
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
