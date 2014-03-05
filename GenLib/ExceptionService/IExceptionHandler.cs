using System;

namespace GenLib.ExceptionService
{
    public interface IExceptionHandler
    {
        bool Notify(string humaneMsg);
        bool Notify(Exception ex);
        bool Notify(Exception ex, string humaneMsg);
    }
}