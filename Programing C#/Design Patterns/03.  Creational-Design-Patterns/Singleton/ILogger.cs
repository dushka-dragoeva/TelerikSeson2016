namespace Singleton
{
    public interface ILogger
    {
        void Log(string message, IPrinter printer);
    }
}