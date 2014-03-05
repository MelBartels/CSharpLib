using System;

namespace GenLib.Extensions
{
    public static class EnumExtension
    {
        public static TIn ConvertTo<TIn>(this string s)
        {
            return (TIn) Enum.Parse(typeof (TIn), s);
        }
    }
}