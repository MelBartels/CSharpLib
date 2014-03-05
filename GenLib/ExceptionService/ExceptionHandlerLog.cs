using System;
using GenLib.Services;

namespace GenLib.ExceptionService
{
    public class ExceptionHandlerLog : ExceptionHandlerBase
    {
        public ExceptionHandlerLog(ExceptionMsg exceptionMsg, LogToFile logToFile) : base(exceptionMsg, logToFile)
        {
        }

        public ExceptionHandlerLog() : this(new ExceptionMsg(), new LogToFile())
        {
        }

        public override bool Notify(Exception ex, string humaneMsg)
        {
            return LogToFile.WriteMsg(ExceptionMsg.Build(ex, humaneMsg));
        }
    }
}