namespace Tessup
{
    interface ILogHandler
    {
        void Trace(string line);
        void Info(string line);
        void Warning(string line);
        void Error(string line);
        void Verbose(string line);
        void Debug(string line);
        void Debug(string line,Tessup.LogHandler.StackInfo si);
        void Fatal(string line);
    }
}
