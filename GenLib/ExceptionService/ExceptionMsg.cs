using System;
using System.Text;
using GenLib.Extensions;
using GenLib.Properties;

namespace GenLib.ExceptionService
{
    public class ExceptionMsg
    {
        public string Build(Exception ex, string humaneMsg)
        {
            return new StringBuilder()
                .Do(sb => AppendHumaneMessage(sb, humaneMsg))
                .Do(sb => ex.Do(e =>
                                    {
                                        AppendLineIfNecessary(sb);
                                        AppendExceptionMessage(sb, e);
                                        AppendInnerException(sb, e);
                                        AppendStackTrace(sb, e);
                                    })
                ).ToString();
        }

        protected void AppendHumaneMessage(StringBuilder sb, string humaneMsg)
        {
            string.IsNullOrEmpty(humaneMsg)
                .Else(() => sb.Append(humaneMsg));
        }

        protected void AppendStackTrace(StringBuilder sb, Exception ex)
        {
            ex.With(e => e)
                .If(e => !string.IsNullOrEmpty(e.StackTrace))
                .Do(e =>
                        {
                            sb.Append(Resources.StackTracePrefix);
                            sb.Append(ex.StackTrace);
                        });
        }

        protected static void AppendInnerException(StringBuilder sb, Exception ex)
        {
            ex.With(e => e)
                .With(e => e.InnerException)
                .If(ie => !string.IsNullOrEmpty(ex.Message))
                .Do(ie =>
                        {
                            sb.Append(Resources.InnerExceptionPrefix);
                            sb.AppendLine(ie.Message);
                            AppendInnerException(sb, ie);
                        });
        }

        protected void AppendExceptionMessage(StringBuilder sb, Exception ex)
        {
            ex.With(e => e)
                .If(e => !string.IsNullOrEmpty(e.Message))
                .Do(e =>
                        {
                            sb.Append(Resources.MessagePrefix);
                            sb.AppendLine(e.Message);
                        });
        }

        protected void AppendLineIfNecessary(StringBuilder sb)
        {
            if (sb.Length > 0)
                sb.AppendLine(string.Empty);
        }
    }
}