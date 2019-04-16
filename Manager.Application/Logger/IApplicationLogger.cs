using System;

namespace Manager.Application.Logger
{
    public interface IApplicationLogger
    {
        void Debug(string message);
        void Error(Exception ex, string message);
        void Fatal(Exception ex, string message);
        void Information(string message);
        void Warn(string message);
    }
}