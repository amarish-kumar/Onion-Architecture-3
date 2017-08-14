using System;

namespace AdamS.OnlineStore.DomainModel
{
    public interface ILogger
    {
        string GetTempPath();
        void Error(string message);
        void Error(string format, params object[] args);
        void Error(Exception ex, string message);
        void Error(Exception ex, string format, params object[] args);
        void Info(string message);
        void Info(string format, params object[] args);
        void Info(Exception ex, string message);
        void Info(Exception ex, string format, params object[] args);
    }
}