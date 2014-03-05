using System;
using GenLib.Services;

namespace GenLib.ExceptionService
{
    public abstract class ExceptionHandlerBase : IExceptionHandler
    {
        protected ExceptionHandlerBase(ExceptionMsg exceptionMsg, LogToFile logToFile)
        {
            ExceptionMsg = exceptionMsg;
            LogToFile = logToFile;
        }

        protected ExceptionMsg ExceptionMsg { get; set; }
        protected LogToFile LogToFile { get; set; }

        #region IExceptionHandler Members

        public bool Notify(string humaneMsg)
        {
            return Notify(null, humaneMsg);
        }

        public bool Notify(Exception ex)
        {
            return Notify(ex, null);
        }

        public abstract bool Notify(Exception ex, string humaneMsg);

        #endregion
    }
}