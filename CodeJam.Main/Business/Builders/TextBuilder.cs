using System.Text;

namespace CodeJam.Main
{
    public class TextBuilder : IBuilder
    {
        private readonly StringBuilder _sb = new StringBuilder();
        public void Append(string line)
        {
            _sb.Append(line);
        }

        public void AppendLine(string line)
        {
            _sb.AppendLine(line);
        }

        public string GetFullString()
        {
            return _sb.ToString();
        }
    }
}
