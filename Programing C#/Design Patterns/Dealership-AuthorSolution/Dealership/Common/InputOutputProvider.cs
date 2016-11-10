using System;

namespace Dealership.Common
{
    public class InputOutputProvider : IInputOutputProvider
    {
        private readonly Action<string> write;
        private readonly Func<string> readLine;

        public InputOutputProvider(Action<string> write, Func<string> readLine)
        {
            this.write = write;
            this.readLine = readLine;
        }

        public string ReadLine()
        {
            return this.readLine();
        }

        public void Write(string message)
        {
            this.write(message);
        }

        public void WriteLine(string message)
        {
            this.write(message);
            this.write(Environment.NewLine);
        }
    }
}
