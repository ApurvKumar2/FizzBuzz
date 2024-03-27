using System;

namespace CodeJam.Main
{
    public class ConsoleBuilderDecorator :IBuilder
    {
        private readonly IBuilder _builder;
        public ConsoleBuilderDecorator(IBuilder builder)
        {
            _builder = builder;
        }
        public void Append(string line)
        {
            _builder.Append(line);
            Console.Write(line);
        }

        public void AppendLine(string line)
        {
            _builder.AppendLine(line);
            Console.WriteLine(line);
        }

        public string GetFullString()
        {
            return _builder.GetFullString();
        }
    }
}
