using System;
using System.Linq;

namespace CodeJam.Main
{
    public class CodeJamCounter : ICounter
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string Separator = " ";

        private readonly Predicate<int> _divisibleBy3 = i => i % 3 == 0;
        private readonly Predicate<int> _divisibleBy5 = i => i % 5 == 0;

        public void Count(IBuilder builder, int number)
        {
            if (number > 0)
                Enumerable.Range(1, number)
                    .ToList()
                    .ForEach(i =>
                    {
                        var line = GetLine(i);
                        builder.Append(i != number ? line + Separator : line);
                    });
        }

        private string GetLine(int number)
        {
            var line = string.Empty;
            
            Check3Divisibility(number, ref line);
            Check5Divisibility(number, ref line);
            CheckFallback(number, ref line);

            return line;
        }

        private void Check3Divisibility(int num, ref string line)
        {
            if (_divisibleBy3.Invoke(num))
                line += Fizz;
        }

        private void Check5Divisibility(int num, ref string line)
        {
            if (_divisibleBy5.Invoke(num))
                line += Buzz;
        }

        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void CheckFallback(int num, ref string line)
        {
            if (string.IsNullOrEmpty(line))
                line = num.ToString();
        }
    }
}
