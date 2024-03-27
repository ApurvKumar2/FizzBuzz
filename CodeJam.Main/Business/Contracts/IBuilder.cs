namespace CodeJam.Main
{
    public interface IBuilder
    {
        void Append(string line);
        void AppendLine(string line);

        string GetFullString();
    }
}
