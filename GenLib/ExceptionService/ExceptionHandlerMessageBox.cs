using System;
using System.Text;
using GenLib.MessageBox;
using GenLib.Services;

namespace GenLib.ExceptionService
{
    public class ExceptionHandlerMessageBox : ExceptionHandlerBase
    {
        public ExceptionHandlerMessageBox(ExceptionMsg exceptionMsg, LogToFile logToFile)
            : base(exceptionMsg, logToFile)
        {
        }

        public ExceptionHandlerMessageBox() : this(new ExceptionMsg(), new LogToFile())
        {
        }

        public override bool Notify(Exception ex, string humaneMsg)
        {
            var exMsg = ExceptionMsg.Build(ex, humaneMsg);
            var rtnResult = ShowMessageBox(exMsg);
            LogToFile.WriteMsg(exMsg);
            return rtnResult;
        }

        protected bool ShowMessageBox(string msg)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Constants.General.ErrorMessage);
            sb.Append(msg);
            AppMessageBox.Show(sb.ToString());
            return true;
        }
    }
}